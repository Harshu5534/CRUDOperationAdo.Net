using System;
namespace CRUDOperations
{
    public class Program
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("---------------------Welcome To Employee PayRoll Service Program-------------------");
            EmpRepository repository = new EmpRepository();
            bool end = true;
            while (end)
            {
                Console.WriteLine("1.To Insert the Data in Data Base \n2.Retrieve All Employee Data from the Data Base\n");
                Console.WriteLine("\nEnter Option For Exicute The Program");
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EmpModel empModel = new EmpModel();
                        empModel.Id = 1;
                        empModel.Name = "Manish";
                        empModel.Gender = "M";
                        empModel.Salary = 50000;
                        empModel.StartDate = DateTime.Now;
                        empModel.PhoneNumber = "9687569089";
                        empModel.Address = "Pune";
                        empModel.DepartMent = "Civil";
                        empModel.Deduction = "500";
                        empModel.Taxable_Pay = "600";
                        empModel.Net_Pay = "200";
                        repository.AddEmployee(empModel);
                        break;
                    case 2:
                        List<EmpModel> empList = repository.GetAllEmployees();
                        foreach (EmpModel data in empList)
                        {
                            Console.WriteLine(data.Id + " " + data.Name + " " + data.Gender + " " + data.Salary + " " + data.StartDate + " " + data.PhoneNumber + " " + data.Address + " " + data.Deduction + " " + data.Taxable_Pay + " " + data.Net_Pay );
                        }
                        break;
                    case 3:
                        end = false;
                        break;
                    default:
                        Console.WriteLine("--------------Please Enter the Correct option--------------");
                        break;
                }
            }
        }
    }
}