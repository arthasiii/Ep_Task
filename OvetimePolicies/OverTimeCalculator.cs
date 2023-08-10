namespace OvetimePolicies
{
    public class OverTimeCalculator
    {

        public int OverTimeCalculatorRequest { get; set; }


        public int hoursworkOfmonth { get; } = 184;

        public double CalcurlatorA(double basesalary)
        {
            //  10  اضافه کار بخاطر نبود تایم کاری اضافه کار برای محاسبهbasesalary
            int timeword = 10;//hour

            int hourssalary = Convert.ToInt32 (basesalary / hoursworkOfmonth);

            double income = (hourssalary * 10) + basesalary;


            


            return income;
        }

        public double CalcurlatorB(double basesalary)
        {
            //  20  اضافه کار بخاطر نبود تایم کاری اضافه کار برای محاسبه
            int timeword = 20;//hour

            int hourssalary = Convert.ToInt32(basesalary / hoursworkOfmonth);

            double income = (hourssalary * 20) + basesalary;

            return income;
        }

        public double CalcurlatorC(double basesalary)
        {
            //  40  اضافه کار بخاطر نبود تایم کاری اضافه کار برای محاسبه
            int timeword = 40;//hour

            int hourssalary = Convert.ToInt32(basesalary / hoursworkOfmonth);

            double income = (hourssalary * 40) + basesalary;

            return income;
        }
    }
}