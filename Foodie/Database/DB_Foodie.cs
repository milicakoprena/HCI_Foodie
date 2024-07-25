using Foodie.Model;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Foodie.Database
{
    internal class DB_Foodie
    {
        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MySqlHciFoodie"].ConnectionString;

        public static Employee AuthenticateEmployee(string username, string password)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT * FROM `employee` WHERE username = @username AND password = @password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           
                            return new Employee()
                            {
                                idEmployee = reader.GetInt32(0),
                                name = reader.GetString(1),
                                surname = reader.GetString(2),
                                username = reader.GetString(3),
                                password = reader.GetString(4),
                                phoneNumber = reader.GetString(5),
                                idRole = reader.GetInt32(6),
                                status = reader.GetBoolean(7),
                                theme = reader.GetInt32(8),
                                language = reader.GetInt32(9)
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public static bool UpdateEmployeeTheme(int idEmployee, int newTheme)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmdUpdateTheme = new MySqlCommand("UPDATE `foodie`.`Employee` SET `theme` = @newTheme WHERE `idEmployee` = @idEmployee;", conn))
                    {
                        cmdUpdateTheme.Parameters.AddWithValue("@idEmployee", idEmployee);
                        cmdUpdateTheme.Parameters.AddWithValue("@newTheme", newTheme);

                        int rowsAffected = cmdUpdateTheme.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom ažuriranja teme zaposlenika: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool UpdateEmployeeLanguage(int idEmployee, int newLanguage)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmdUpdateLan = new MySqlCommand("UPDATE `foodie`.`Employee` SET `language` = @newLanguage WHERE `idEmployee` = @idEmployee;", conn))
                    {
                        cmdUpdateLan.Parameters.AddWithValue("@idEmployee", idEmployee);
                        cmdUpdateLan.Parameters.AddWithValue("@newLanguage", newLanguage);

                        int rowsAffected = cmdUpdateLan.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom ažuriranja jezika zaposlenika: " + ex.Message);
                    return false;
                }
            }
        }

        public static List<DishCategory> GetDishCategories()
        {
            List<DishCategory> result = new List<DishCategory>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT idDishCategory, name FROM `dishcategory`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new DishCategory()
                {
                    idDishCategory = reader.GetInt32(0),
                    name = reader.GetString(1)
                });
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static List<Dish> GetDishes()
        {

            List<Dish> result = new List<Dish>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT d.idDish, d.name, d.price, d.idDishCategory, dc.name as DishCategoryName " +
                              "FROM dish d " +
                              "JOIN dishcategory dc ON d.idDishCategory = dc.idDishCategory";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Dish dish = new Dish()
                {
                    idDish = reader.GetInt32(0),
                    name = reader.GetString(1),
                    price = reader.GetDouble(2),
                    idDishCategory = reader.GetInt32(3),
                    dishCategoryName = reader.GetString(4)
                };

               
                result.Add(dish);
            }

            reader.Close();
            conn.Close();

            return result;
        }

        public static List<Employee> GetEmployees()
        {
            List<Employee> result = new List<Employee>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM `employee`";
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                if(reader.GetInt32(6) == 2) {
                    result.Add(new Employee()
                    {
                        idEmployee = reader.GetInt32(0),
                        name = reader.GetString(1),
                        surname = reader.GetString(2),
                        username = reader.GetString(3),
                        password = reader.GetString(4),
                        phoneNumber = reader.GetString(5),
                        idRole = reader.GetInt32(6),
                        status = reader.GetBoolean(7),
                    });
                }
                
            }
            reader.Close();
            conn.Close();
            return result;
        }

        public static bool InsertEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmdInsertEmployee = new MySqlCommand("INSERT INTO employee (name, surname, username, password, phoneNumber, idRole, status, theme, language) VALUES (@name, @surname, @username, @password, @phoneNumber, '2', '1', '1', '1');", conn))
                    {
                        cmdInsertEmployee.Parameters.AddWithValue("@name", employee.name);
                        cmdInsertEmployee.Parameters.AddWithValue("@surname", employee.surname);
                        cmdInsertEmployee.Parameters.AddWithValue("@username", employee.username);
                        cmdInsertEmployee.Parameters.AddWithValue("@password", employee.password);
                        cmdInsertEmployee.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);

                        int rowsAffected = cmdInsertEmployee.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom dodavanja zaposlenika: " + ex.Message);
                    return false;
                }
            }
        }

        public static bool UpdateEmployee(Employee employee)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmdUpdateEmployee = new MySqlCommand("UPDATE employee SET name = @name, surname = @surname, username = @username, password = @password, phoneNumber = @phoneNumber WHERE idEmployee = @idEmployee;", conn))
                    {
                        cmdUpdateEmployee.Parameters.AddWithValue("@name", employee.name);
                        cmdUpdateEmployee.Parameters.AddWithValue("@surname", employee.surname);
                        cmdUpdateEmployee.Parameters.AddWithValue("@username", employee.username);
                        cmdUpdateEmployee.Parameters.AddWithValue("@password", employee.password);
                        cmdUpdateEmployee.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                        cmdUpdateEmployee.Parameters.AddWithValue("@idEmployee", employee.idEmployee); 

                        int rowsAffected = cmdUpdateEmployee.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom ažuriranja zaposlenika: " + ex.Message);
                    return false;
                }
            }
        }


        public static bool UpdateEmployeeStatus(int idEmployee, bool newStatus)
        {
           using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = "UPDATE employee SET status = @newStatus WHERE idEmployee = @idEmployee";

                    using (MySqlCommand cmdUpdateStatus = new MySqlCommand(query, conn))
                    {
                        cmdUpdateStatus.Parameters.AddWithValue("@newStatus", newStatus);
                        cmdUpdateStatus.Parameters.AddWithValue("@idEmployee", idEmployee);

                        int rowsAffected = cmdUpdateStatus.ExecuteNonQuery();

                        return rowsAffected > 0; 
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom ažuriranja statusa zaposlenika: " + ex.Message);
                    return false; 
                }
            }
        }



        public static bool InsertReceiptWithDishItems(double receiptPrice, List<DishItem> dishItems)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdInsertReceipt = new MySqlCommand("INSERT INTO receipt (orderTime, totalPrice, idEmployee) VALUES (NOW(), @totalPrice, @idEmployee); SELECT LAST_INSERT_ID();", conn, transaction))
                    {
                        cmdInsertReceipt.Parameters.AddWithValue("@totalPrice", receiptPrice);
                        cmdInsertReceipt.Parameters.AddWithValue("@idEmployee", LoginForm.employee.idEmployee);

                        int idReceipt = Convert.ToInt32(cmdInsertReceipt.ExecuteScalar());

                        foreach (DishItem dishItem in dishItems)
                        {
                            using (MySqlCommand cmdInsertDishItem = new MySqlCommand("INSERT INTO dishitem (amount, totalPrice, idDish, idReceipt) VALUES (@amount, @totalPrice, @idDish, @idReceipt);", conn, transaction))
                            {
                                cmdInsertDishItem.Parameters.AddWithValue("@amount", dishItem.amount);
                                cmdInsertDishItem.Parameters.AddWithValue("@totalPrice", dishItem.totalPrice);
                                cmdInsertDishItem.Parameters.AddWithValue("@idDish", dishItem.idDish);
                                cmdInsertDishItem.Parameters.AddWithValue("@idReceipt", idReceipt);

                                cmdInsertDishItem.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        return true; 
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                    return false;
                }
            }
        }


        public static List<Receipt> GetReceipts()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<Receipt> result = new List<Receipt>();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdGetReceipt = new MySqlCommand("SELECT receipt.*, employee.name, employee.surname FROM receipt JOIN employee ON receipt.idEmployee = Employee.idEmployee;", conn, transaction))
                    {

                        MySqlDataReader reader = cmdGetReceipt.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Receipt()
                            {
                                idReceipt = reader.GetInt32(0),
                                orderTime = reader.GetDateTime(1),
                                totalPrice = reader.GetDouble(2),
                                idEmployee = reader.GetInt32(3),
                                employee = reader.GetString(4) + " " + reader.GetString(5),
                                dishItems = GetDishItemsByIdReceipt(reader.GetInt32(0))
                            });

                        }
                        reader.Close();
                        transaction.Commit();  
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                    return result;
                }
                finally
                {
                    conn.Close();  
                }
            }
        }

        public static List<Receipt> GetReceiptsByEmployeeId(int idEmployee)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<Receipt> result = new List<Receipt>();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdGetReceiptsByEmployeeId = new MySqlCommand("SELECT `receipt`.*, employee.name, employee.surname FROM `receipt` JOIN employee ON `receipt`.idEmployee = employee.idEmployee WHERE `receipt`.idEmployee = @idEmployee;", conn, transaction))
                    {
                        cmdGetReceiptsByEmployeeId.Parameters.AddWithValue("@idEmployee", idEmployee);

                        MySqlDataReader reader = cmdGetReceiptsByEmployeeId.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Receipt()
                            {
                                idReceipt = reader.GetInt32(0),
                                orderTime = reader.GetDateTime(1),
                                totalPrice = reader.GetDouble(2),
                                idEmployee = reader.GetInt32(3),
                                employee = reader.GetString(4) + " " + reader.GetString(5),
                                dishItems = GetDishItemsByIdReceipt(reader.GetInt32(0))
                            });
                        }
                        reader.Close();
                        transaction.Commit();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                    return result;
                }
                finally
                {
                    conn.Close();
                }
            }
        }


        public static List<Receipt> FilterReceiptsByDate(DateTime startDate, DateTime endDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<Receipt> result = new List<Receipt>();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdGetReceipt = new MySqlCommand("SELECT receipt.*, employee.name, employee.surname FROM receipt JOIN employee ON receipt.idEmployee = Employee.idEmployee WHERE receipt.orderTime BETWEEN @startDate AND @endDate;", conn, transaction))
                    {
                        cmdGetReceipt.Parameters.AddWithValue("@startDate", startDate);
                        cmdGetReceipt.Parameters.AddWithValue("@endDate", endDate);

                        MySqlDataReader reader = cmdGetReceipt.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Receipt()
                            {
                                idReceipt = reader.GetInt32(0),
                                orderTime = reader.GetDateTime(1),
                                totalPrice = reader.GetDouble(2),
                                idEmployee = reader.GetInt32(3),
                                employee = reader.GetString(4) + " " + reader.GetString(5),
                                dishItems = GetDishItemsByIdReceipt(reader.GetInt32(0))
                            });
                        }
                        reader.Close();
                        transaction.Commit();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                    return result;
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        public static List<DishItem> GetDishItemsByIdReceipt(int idReceipt)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<DishItem> result = new List<DishItem>();
                string query = "SELECT dishitem.*, dish.name AS dishname FROM dishitem JOIN dish ON dishitem.idDish = dish.idDish WHERE dishitem.idReceipt = @idReceipt;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idReceipt", idReceipt);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new DishItem()
                            {
                                amount = reader.GetByte(1),
                                totalPrice = reader.GetDouble(2),
                                dishName = reader.GetString(5)
                            });
                        }
                        reader.Close();
                        conn.Close();
                        return result;
                    }
                }
            }
        }

        public static bool InsertDish(Dish dish)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    using (MySqlCommand cmdInsertDish = new MySqlCommand("INSERT INTO dish (name, price, idDishCategory) VALUES (@name, @price, @idDishCategory);", conn))
                    {
                        cmdInsertDish.Parameters.AddWithValue("@name", dish.name);
                        cmdInsertDish.Parameters.AddWithValue("@price", dish.price);
                        cmdInsertDish.Parameters.AddWithValue("@idDishCategory", dish.idDishCategory);

                        int rowsAffected = cmdInsertDish.ExecuteNonQuery();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Greška prilikom dodavanja jela: " + ex.Message);
                    return false;
                }
            }
        }


        public static List<Groceries> GetGroceries()
        {

            List<Groceries> result = new List<Groceries>();
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT g.idGroceries, g.name, g.price, g.idGroceriesUnit, gi.name as GroceriesUnitName " +
                              "FROM groceries g " +
                              "JOIN groceriesunit gi ON g.idGroceriesUnit = gi.idGroceriesUnit";

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Groceries groceries = new Groceries()
                {
                    idGroceries = reader.GetInt32(0),
                    name = reader.GetString(1),
                    price = reader.GetDouble(2),
                    idGroceriesUnit = reader.GetInt32(3),
                    unitName = reader.GetString(4)
                };


                result.Add(groceries);
            }

            reader.Close();
            conn.Close();

            return result;
        }

        public static void InsertOrderWithGroceriesItems(double orderPrice, List<GroceriesItem> groceriesItems)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdInsertOrder = new MySqlCommand("INSERT INTO `order` (orderTime, totalPrice, idEmployee) VALUES (NOW(), @totalPrice, @idEmployee); SELECT LAST_INSERT_ID();", conn, transaction))
                    {
                        cmdInsertOrder.Parameters.AddWithValue("@totalPrice", orderPrice);
                        cmdInsertOrder.Parameters.AddWithValue("@idEmployee", LoginForm.employee.idEmployee);

                        int idOrder = Convert.ToInt32(cmdInsertOrder.ExecuteScalar());

                        foreach (GroceriesItem groceriesItem in groceriesItems)
                        {
                            using (MySqlCommand cmdInsertGroceriesItem = new MySqlCommand("INSERT INTO `groceriesitem` (amount, totalPrice, idGroceries, idOrder) VALUES (@amount, @totalPrice, @idGroceries, @idOrder);", conn, transaction))
                            {
                                cmdInsertGroceriesItem.Parameters.AddWithValue("@amount", groceriesItem.amount);
                                cmdInsertGroceriesItem.Parameters.AddWithValue("@totalPrice", groceriesItem.totalPrice);
                                cmdInsertGroceriesItem.Parameters.AddWithValue("@idGroceries", groceriesItem.idGroceries);
                                cmdInsertGroceriesItem.Parameters.AddWithValue("@idOrder", idOrder);

                                cmdInsertGroceriesItem.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                }
            }
        }
        public static List<Order> GetOrders()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<Order> result = new List<Order>();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdGetOrder = new MySqlCommand("SELECT `order`.*, employee.name, employee.surname FROM `order` JOIN employee ON `order`.idEmployee = employee.idEmployee;", conn, transaction))
                    {
                        MySqlDataReader reader = cmdGetOrder.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Order()
                            {
                                idOrder = reader.GetInt32(0),
                                orderTime = reader.GetDateTime(1),
                                totalPrice = reader.GetDouble(2),
                                idEmployee = reader.GetInt32(3),
                                employee = reader.GetString(4) + " " + reader.GetString(5),
                                groceriesItems = GetGroceriesItemsByIdOrder(reader.GetInt32(0))
                            });
                        }
                        reader.Close();
                        transaction.Commit();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                    return result;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static List<Order> FilterOrdersByDate(DateTime startDate, DateTime endDate)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<Order> result = new List<Order>();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    using (MySqlCommand cmdGetOrder = new MySqlCommand("SELECT `order`.*, employee.name, employee.surname FROM `order` JOIN employee ON `order`.idEmployee = employee.idEmployee WHERE `order`.orderTime BETWEEN @startDate AND @endDate;", conn, transaction))
                    {
                        cmdGetOrder.Parameters.AddWithValue("@startDate", startDate);
                        cmdGetOrder.Parameters.AddWithValue("@endDate", endDate);

                        MySqlDataReader reader = cmdGetOrder.ExecuteReader();
                        while (reader.Read())
                        {
                            result.Add(new Order()
                            {
                                idOrder = reader.GetInt32(0),
                                orderTime = reader.GetDateTime(1),
                                totalPrice = reader.GetDouble(2),
                                idEmployee = reader.GetInt32(3),
                                employee = reader.GetString(4) + " " + reader.GetString(5),
                                groceriesItems = GetGroceriesItemsByIdOrder(reader.GetInt32(0))
                            });
                        }
                        reader.Close();
                        transaction.Commit();
                        return result;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine("Greška prilikom izvršavanja transakcije: " + ex.Message);
                    return result;
                }
                finally
                {
                    conn.Close();
                }
            }
        }



        public static List<GroceriesItem> GetGroceriesItemsByIdOrder(int idOrder)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                List<GroceriesItem> result = new List<GroceriesItem>();
                string query = "SELECT groceriesitem.*, groceries.name AS groceriesname FROM groceriesitem JOIN groceries ON groceriesitem.idGroceries = groceries.idGroceries WHERE groceriesitem.idOrder = @idOrder;";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new GroceriesItem()
                            {
                                amount = reader.GetByte(1),
                                totalPrice = reader.GetDouble(2),
                                groceriesName = reader.GetString(5)
                            });
                        }
                        reader.Close();
                        conn.Close();
                        return result;
                    }
                }
            }
        }

    }
}
