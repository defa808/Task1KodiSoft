using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task1KodiSoft.Data;
using Task1KodiSoft.Models;
using Task1KodiSoft.ViewModels;

namespace Task1KodiSoft.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db;
        private readonly int  countColumn = 7;
        public HomeController(ApplicationDbContext context)
        {
            UpdateRecordsOrder(context);
            db = context;
        }

        private static void UpdateRecordsOrder(ApplicationDbContext context)
        {
            List<Order> orders = context.Orders.ToList();
            foreach (Order item in orders)
            {
                item.TotalPrice = context.OrderItemOrders.
                    Where(o => o.Order == item &&
                    (o.Order.State.Id == 3)).
                     Sum(o => o.CurrentPrice);
            }
            context.SaveChanges();
        }

        public IActionResult Index()
        {
            OrdersFieldsViewModel orderFieldsViewModel = InitAndGetOrdersFieldsViewModel();
            return View(orderFieldsViewModel);
        }

        [HttpPost]
        public IActionResult ShowGrafic(ModeEnum choosen_mode, DateEnum choosen_date)
        {

            GraficViewModel graficViewModel = InitAndGetGraficViewModel(choosen_mode, choosen_date);

            return PartialView(graficViewModel);

        }

        private GraficViewModel InitAndGetGraficViewModel(ModeEnum choosen_mode, DateEnum choosen_date)
        {
            List<double> values = BuildValues(choosen_mode, choosen_date);

            List<double> fillPercentage = BuildPercentage(values);

            List<string> datePeriod = BuildDatePeriod(choosen_date);

            return new GraficViewModel()
            {
                Values = values.ConvertAll<string>(o => o.ToString()),
                FillPercentage = fillPercentage,
                DatePeriod = datePeriod
            };

        }
        private List<double> BuildValues(ModeEnum choosen_mode, DateEnum choosen_date)
        {
            List<double> values = new List<double>();

            List<IQueryable<Order>> queries = new List<IQueryable<Order>>();

            switch (choosen_date)
            {
                case DateEnum.Month:
                    {
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            DateTime date = DateTime.Now.Date.AddMonths(-i);
                            queries.Add(db.Orders.Where(o =>
                            o.ClosedDate.Year.Equals(date.Year) &&
                            o.ClosedDate.Month.Equals(date.Month)
                            ));
                        }
                        break;
                    }

                case DateEnum.Week:
                    {
                        DateTimeFormatInfo dateTimeInfo = DateTimeFormatInfo.CurrentInfo;
                        Calendar cal = dateTimeInfo.Calendar;

                        for (int i = countColumn-1; i >= 0; i--)
                        {

                            DateTime date = DateTime.Now.Date.AddDays(7 * -i);
                            int week = cal.GetWeekOfYear(date, dateTimeInfo.CalendarWeekRule, dateTimeInfo.FirstDayOfWeek);
                            queries.Add(db.Orders.Where(o =>
                            o.ClosedDate.Year.Equals(date.Year) &&
                           ((o.ClosedDate.DayOfYear - 1) / 7 + 1).Equals(week)));
                        }
                        break;
                    }

                case DateEnum.Day:
                    {
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            DateTime date = DateTime.Now.Date.AddDays(-i);
                            queries.Add(db.Orders.Where(o => o.ClosedDate.Date.Equals(date)));
                        }
                        break;
                    }

                default:
                    {
                        //DateEnum.Day
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            DateTime date = DateTime.Now.Date.AddDays(-i);
                            queries.Add(db.Orders.Where(o => o.ClosedDate.Date.Equals(date)));
                        }
                        break;
                    }
            }

            switch (choosen_mode)
            {
                case ModeEnum.NumberOrders:
                    {
                        for (int i = 0; i < countColumn; i++)
                        {
                            values.Add(queries[i].Count());
                        }
                        break;
                    }

                case ModeEnum.Money:
                    {
                        for (int i = 0; i < countColumn; i++)
                        {
                            values.Add(queries[i].Sum(o => o.TotalPrice));
                        }
                        break;
                    }
            }

            return values;
        }
        private List<double> BuildPercentage(List<double> values)
        {
            double maxValue = values.Max();
            List<double> fillPercentage = new List<double>();
            if (maxValue != 0)
            {
                for (int i = 0; i < countColumn; i++)
                {
                    fillPercentage.Add(values[i] / maxValue * 100);
                }
            }
            return fillPercentage;
        }
        private List<string> BuildDatePeriod(DateEnum choosen_date)
        {
            List<string> datePeriod = new List<string>();

            switch (choosen_date)
            {
                case DateEnum.Month:
                    {
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            datePeriod.Add((DateTime.Now.AddMonths(-i).ToString("MMM")));
                        }
                        break;
                    }


                case DateEnum.Week:
                    {
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                            Calendar cal = dfi.Calendar;
                            var currentDate = DateTime.Now.AddDays(-7 * i);
                            var weekNum = cal.GetWeekOfYear(currentDate, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
                            datePeriod.Add(weekNum.ToString());
                        }
                        break;
                    }

                case DateEnum.Day:
                    {
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            datePeriod.Add((DateTime.Now.AddDays(-i).ToString("dd")));
                        }
                        break;
                    }

                default:
                    {
                        //DateEnum.Day
                        for (int i = countColumn-1; i >= 0; i--)
                        {
                            datePeriod.Add((DateTime.Now.AddDays(-i).ToString("dd")));
                        }
                        break;
                    }
            }

            return datePeriod;
        }

        private OrdersFieldsViewModel InitAndGetOrdersFieldsViewModel()
        {
            double amountMoney = db.Orders.Sum(s => s.TotalPrice);
            int numberOrders = db.Orders.Count();
            double averageCheck = 0;
            if (numberOrders != 0)
                averageCheck = amountMoney / numberOrders;
            int totalOrderedItems = db.OrderItemOrders.Count();

            return new OrdersFieldsViewModel()
            {
                AverageCheck = averageCheck,
                AmountMoney = amountMoney,
                NumbersOrders = numberOrders,
                TotalOrderedItems = totalOrderedItems
            };


        }

        public IActionResult ShowFoods()
        {

            List<FoodItemViewModel> topOrders = db.OrderItemOrders.
                GroupBy(o => o.OrderItem).
                OrderByDescending(o => o.Count()).
                Select(o => new FoodItemViewModel
                {
                    OrderItem = o.Key,
                    TotalCount = o.Count(),
                    TotalAmountSum = o.Sum(p => p.CurrentPrice)
                }).Take(10).ToList();

            List<FoodItemViewModel> unordered = db.OrderItemOrders.
                GroupBy(o => o.OrderItem).
                OrderBy(o => o.Count()).
                Select(o => new FoodItemViewModel
                {
                    OrderItem = o.Key,
                    TotalCount = o.Count(),
                    TotalAmountSum = o.Sum(p => p.CurrentPrice)
                }).Take(10).ToList();


            FoodViewModel foodViewModel = new FoodViewModel()
            {
                TopOrders = topOrders,
                Unordered = unordered
            };


            return PartialView(foodViewModel);
        }


        public IActionResult ShowPayments()
        {
            double operationNumberCredit = db.Orders.Count(o => o.isCash == false);
            double operationNumberCash = db.Orders.Count(o => o.isCash == true);

            double amountMoneyCredit = db.Orders.Where(o => o.isCash == false).Sum(o => o.TotalPrice);
            double amountMoneyCash = db.Orders.Where(o => o.isCash == true).Sum(o => o.TotalPrice);
            double tipsNumber = db.Orders.Where(o => o.TipsAmount > 0).Count();

            double tipsSum = db.Orders.Sum(o => o.TipsAmount);
            double tipsAveragePercent = 0;
            if (amountMoneyCash + amountMoneyCredit != 0)
            {
                tipsAveragePercent = tipsSum / (amountMoneyCash + amountMoneyCredit) * 100;
            }

            PaymentViewModel paymentViewModel = new PaymentViewModel()
            {
                OperationNumberCash = operationNumberCash,
                OperationNumberCredit = operationNumberCredit,
                AmountMoneyCash = amountMoneyCash,
                AmountMoneyCredit = amountMoneyCredit,
                TipsAverage = tipsAveragePercent,
                TipsNumber = tipsNumber,
                TipsSum = tipsSum
            };

            return PartialView(paymentViewModel);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
