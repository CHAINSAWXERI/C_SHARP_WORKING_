using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Задача 1 (Where)");
        whereTSK1();
    }

    public static void whereTSK1()
    {
        List<Person> people = new List<Person>
        {
            new Person { Name = "John", Age = 30 },
            new Person { Name = "Alice", Age = 25 },
            new Person { Name = "Bob", Age = 40 }
        };

        var youngPeople = people.Where(person => person.Age < 30);

        foreach (var person in youngPeople)
        {
            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }
    }

    public static void whereTSK2()
    {
        List<Session> sessions = new List<Session>
        {
            new Session { UserId = 1, StartTime = new DateTime(2022, 1, 1, 10, 0, 0), EndTime = new DateTime(2022, 1, 1, 12, 0, 0) },
            new Session { UserId = 1, StartTime = new DateTime(2022, 1, 2, 8, 0, 0), EndTime = new DateTime(2022, 1, 2, 18, 0, 0) },
        };

        DateTime lastMonth = DateTime.Now.AddMonths(-1);

        var usersWithLongSessions = sessions
            .Where(s => s.StartTime > lastMonth)
            .GroupBy(s => s.UserId)
            .Where(g => g.Sum(s => (s.EndTime - s.StartTime).TotalHours) > 24 && g.Count() >= 10)
            .Select(g => g.Key);

        foreach (var userId in usersWithLongSessions)
        {
            Console.WriteLine($"User {userId} spent more than 24 hours on the site and had at least 10 sessions in the last month.");
        }
    }

    public static void selectTSK1()
    {
        List<Purchase> purchases = new List<Purchase>
        {
            new Purchase { UserId = 1, ProductId = 101, PurchaseDate = new DateTime(2022, 1, 1) },
            new Purchase { UserId = 1, ProductId = 102, PurchaseDate = new DateTime(2022, 1, 3) },
        };

        var userPurchases = purchases.GroupBy(p => p.UserId);

        var recommendations = userPurchases.SelectMany(g =>
            g.SelectMany(p => userPurchases
                .Where(ug => ug.Key != g.Key)
                .SelectMany(ug => ug.GroupBy(up => up.ProductId))
                .OrderByDescending(ug => ug.Count())
                .SelectMany(ug => ug.Take(5))
            ).Distinct()
        );

        foreach (var recommendation in recommendations)
        {
            Console.WriteLine($"User {recommendation.UserId} may also like product {recommendation.ProductId}");
        }
    }

    public static void orderbyTSK1()
    {
        List<FinancialReport> reports = new List<FinancialReport>
        {
            new FinancialReport { CompanyName = "Company A", Profit = 10000, Loss = 5000, SalesVolume = 200000 },
            new FinancialReport { CompanyName = "Company B", Profit = 15000, Loss = 2000, SalesVolume = 180000 },
        };

        var sortedReports = reports.OrderByDescending(r => r.Profit)
                                    .ThenBy(r => r.Loss)
                                    .ThenBy(r => r.SalesVolume);

        foreach (var report in sortedReports)
        {
            Console.WriteLine($"Company: {report.CompanyName}, Profit: {report.Profit}, Loss: {report.Loss}, Sales Volume: {report.SalesVolume}");
        }
    }

    public static void orderbyTSK2()
    {
        List<LogisticRoute> routes = new List<LogisticRoute>
        {
            new LogisticRoute { RouteId = 1, DeparturePoint = "City A", DestinationPoint = "City B", Distance = 200, ShipmentsCount = 10 },
            new LogisticRoute { RouteId = 2, DeparturePoint = "City C", DestinationPoint = "City D", Distance = 150, ShipmentsCount = 5 },
        };

        var sortedRoutes = routes.OrderBy(r => r.Distance / r.ShipmentsCount);

        var top10Routes = sortedRoutes.Take(10);

        foreach (var route in top10Routes)
        {
            Console.WriteLine($"Route ID: {route.RouteId}, Departure: {route.DeparturePoint}, Destination: {route.DestinationPoint}, Efficiency: {route.Distance / route.ShipmentsCount}");
        }
    }

    public static void AregTSK1()
    {
        List<OrderTsk1> orders = new List<OrderTsk1>
        {
            new OrderTsk1 { OrderId = 1, Category = "Electronics", TotalAmount = 1000 },
            new OrderTsk1 { OrderId = 2, Category = "Clothing", TotalAmount = 500 },
            new OrderTsk1 { OrderId = 3, Category = "Electronics", TotalAmount = 1500 },
            new OrderTsk1 { OrderId = 4, Category = "Books", TotalAmount = 300 },
        };

        var averageOrderCostByCategory = orders.GroupBy(o => o.Category)
            .Select(g => new
            {
                Category = g.Key,
                AverageOrderCost = g.Average(o => o.TotalAmount)
            });

        foreach (var result in averageOrderCostByCategory)
        {
            Console.WriteLine($"Average order cost for category '{result.Category}': {result.AverageOrderCost}");
        }

        var totalSalesByCategory = orders.GroupBy(o => o.Category)
            .Select(g => new
            {
                Category = g.Key,
                TotalSales = g.Sum(o => o.TotalAmount)
            });

        var categoryWithMaxSales = totalSalesByCategory.OrderByDescending(c => c.TotalSales).First();
        var categoryWithMinSales = totalSalesByCategory.OrderBy(c => c.TotalSales).First();

        Console.WriteLine($"Category with the highest sales: {categoryWithMaxSales.Category}, Total Sales: {categoryWithMaxSales.TotalSales}");
        Console.WriteLine($"Category with the lowest sales: {categoryWithMinSales.Category}, Total Sales: {categoryWithMinSales.TotalSales}");
    }

    public static void AregTSK2()
    {
        List<OrderTsk2> orders = new List<OrderTsk2>
        {
            new OrderTsk2 { OrderId = 1, Category = "Electronics", Region = "North", Date = new DateTime(2022, 1, 15), TotalAmount = 100 },
            new OrderTsk2 { OrderId = 2, Category = "Clothing", Region = "South", Date = new DateTime(2022, 1, 20), TotalAmount = 50 },
            new OrderTsk2 { OrderId = 3, Category = "Books", Region = "North", Date = new DateTime(2022, 2, 5), TotalAmount = 200 },
        };

        var report = orders.GroupBy(o => new { o.Category, o.Region, o.Date.Month })
            .Select(g => new
            {
                Category = g.Key.Category,
                Region = g.Key.Region,
                Month = g.Key.Month,
                TotalOrders = g.Count(),
                TotalAmount = g.Sum(o => o.TotalAmount),
                AverageAmount = g.Average(o => o.TotalAmount)
            });

        var totalOrdersByRegionAndMonth = orders.GroupBy(o => new { o.Region, o.Date.Month })
            .Select(g => new
            {
                Region = g.Key.Region,
                Month = g.Key.Month,
                TotalOrders = g.Count()
            });

        var totalOrdersAllCategoriesByRegionAndMonth = totalOrdersByRegionAndMonth.Sum(r => r.TotalOrders);

        var reportWithActivityCoefficient = report.Select(r => new
        {
            r.Category,
            r.Region,
            r.Month,
            r.TotalOrders,
            r.TotalAmount,
            r.AverageAmount,
            ActivityCoefficient = (double)r.TotalOrders / totalOrdersAllCategoriesByRegionAndMonth
        });

        foreach (var result in reportWithActivityCoefficient)
        {
            Console.WriteLine($"Category: {result.Category}, Region: {result.Region}, Month: {result.Month}");
            Console.WriteLine($"Total Orders: {result.TotalOrders}, Total Amount: {result.TotalAmount}, Average Amount: {result.AverageAmount}");
            Console.WriteLine($"Activity Coefficient: {result.ActivityCoefficient}");
            Console.WriteLine();
        }
    }

    public static void groupbyTsk1()
    {
        List<Project> projects = new List<Project>
        {
            new Project
            {
                Name = "Project A",
                Tasks = new List<Task>
                {
                    new Task { Description = "Task 1", Priority = 1, Completion = 50 },
                    new Task { Description = "Task 2", Priority = 2, Completion = 75 },
                    new Task { Description = "Task 3", Priority = 1, Completion = 100 }
                }
            },
            new Project
            {
                Name = "Project B",
                Tasks = new List<Task>
                {
                    new Task { Description = "Task 1", Priority = 2, Completion = 25 },
                    new Task { Description = "Task 2", Priority = 1, Completion = 50 },
                    new Task { Description = "Task 3", Priority = 1, Completion = 80 }
                }
            }
        };

        var groupedTasksByPriorityAndCompletion = projects.SelectMany(p => p.Tasks)
            .GroupBy(t => t.Priority)
            .Select(g => new
            {
                Priority = g.Key,
                TotalCompletion = g.Sum(t => t.Completion)
            });

        var groupedTasksByProjectAndPriority = projects.Select(p => new
        {
            ProjectName = p.Name,
            TasksByPriority = p.Tasks.GroupBy(t => t.Priority)
                                    .Select(g => new
                                    {
                                        Priority = g.Key,
                                        TotalCompletion = g.Sum(t => t.Completion)
                                    })
        });

        foreach (var project in groupedTasksByProjectAndPriority)
        {
            Console.WriteLine($"Project: {project.ProjectName}");
            foreach (var taskGroup in project.TasksByPriority)
            {
                Console.WriteLine($"\tPriority: {taskGroup.Priority}, Total Completion: {taskGroup.TotalCompletion}");
            }
        }
    }

    public static void groupbyTsk2()
    {
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "John Doe", StartDate = new DateTime(2010, 1, 1), EndDate = new DateTime(2013, 12, 31) },
            new Employee { Name = "Alice Smith", StartDate = new DateTime(2012, 3, 15), EndDate = new DateTime(2015, 6, 30) },
            new Employee { Name = "Bob Johnson", StartDate = new DateTime(2011, 7, 1), EndDate = new DateTime(2014, 5, 10) },
            new Employee { Name = "Emily Brown", StartDate = new DateTime(2013, 2, 10), EndDate = new DateTime(2016, 8, 20) }
        };

        var groupedEmployeesByYear = employees.SelectMany(e =>
        {
            var yearsWorked = Enumerable.Range(e.StartDate.Year, e.EndDate.Year - e.StartDate.Year + 1);
            return yearsWorked.Select(year => new { Year = year, Employee = e });
        })
        .GroupBy(x => x.Year);

        foreach (var group in groupedEmployeesByYear)
        {
            int totalEmployeesInYear = group.Select(x => x.Employee).Distinct().Count();
            double averageTenureInYear = group.Average(x => (x.Employee.EndDate - x.Employee.StartDate).TotalDays);

            Console.WriteLine($"Year: {group.Key}");
            Console.WriteLine($"\tTotal Employees: {totalEmployeesInYear}");
            Console.WriteLine($"\tAverage Tenure: {averageTenureInYear:F2} days");
        }
    }
}

public class Person
{
    public string Name;
    public int Age;
}

public class Session
{
    public int UserId;
    public DateTime StartTime;
    public DateTime EndTime;
}

public class Purchase
{
    public int UserId;
    public int ProductId;
    public DateTime PurchaseDate;
}

public class FinancialReport
{
    public string CompanyName;
    public decimal Profit;
    public decimal Loss;
    public decimal SalesVolume;
}

public class LogisticRoute
{
    public int RouteId;
    public string DeparturePoint;
    public string DestinationPoint;
    public decimal Distance;
    public int ShipmentsCount;
}

public class OrderTsk1
{
    public int OrderId;
    public string Category;
    public decimal TotalAmount;
}

public class OrderTsk2
{
    public int OrderId;
    public string Category;
    public string Region;
    public DateTime Date;
    public decimal TotalAmount;
}

public class Task
{
    public string Description;
    public int Priority;
    public int Completion;
}

public class Project
{
    public string Name;
    public List<Task> Tasks;
}

public class Employee
{
    public string Name;
    public DateTime StartDate;
    public DateTime EndDate;
}