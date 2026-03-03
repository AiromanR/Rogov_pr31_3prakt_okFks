using CinemaTicketSystem;

namespace Rogov_pr31_3prakt_okFks
{
    public class RogovTestsForCalcPrice
    {
        const int BasePrice = 300;

        const int ResultFreeChildUnder6 = 0;
        const int ResultChildDiscount = 180;
        const int ResultStudentDiscount = 240; 
        const int ResultPensionerDiscount = 150;
        const int ResultWednesdayDiscount = 210; 
        const int ResultMorningDiscount = 255;
        
        const int ResultVipMultiplier = 600;
        const int ResultVipAfterPensionerDiscount = 300;
        const int ResultVipAfterStudentDiscount = 480;
        const int ResultVipAfterWednesdayDiscount = 420;

        //Границы возрастов
        [Fact]
        public void CalculatePrice_Return0_AgeIs0() //Граница
        {
            var r = new TicketRequest { Age = 0, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultFreeChildUnder6, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return0_AgeIs5() //Граница
        {
            var r = new TicketRequest { Age = 5, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultFreeChildUnder6, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return180_AgeIs6() //Граница
        {
            var r = new TicketRequest { Age = 6, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultChildDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return180_AgeIs17() //Граница
        {
            var r = new TicketRequest { Age = 17, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultChildDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return180_StudentAge17() //ГраницаСтудент
        {
            var r = new TicketRequest { Age = 17, IsStudent = true, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultStudentDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return240_StudentAge25() //ГраницаСтудент
        {
            var r = new TicketRequest { Age = 25, IsStudent = true, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultStudentDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_NotStudentAge18() //ГраницаСтудента(не студент)
        {
            var r = new TicketRequest { Age = 18, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(BasePrice, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_NotStudentAge25() //ГраницаСтудента(не студент)
        {
            var r = new TicketRequest { Age = 25, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(BasePrice, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return150_PensionerAge65() //Граница
        {
            var r = new TicketRequest { Age = 65, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultPensionerDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return150_PensionerAge120() //Граница
        {
            var r = new TicketRequest { Age = 120, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultPensionerDiscount, calc.CalculatePrice(r));
        }

        //Промежутки
        [Fact]
        public void CalculatePrice_Return0_AgeBetween1And5()
        {
            var r = new TicketRequest { Age = 4, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultFreeChildUnder6, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return180_AgeBetween6And17()
        {
            var r = new TicketRequest { Age = 10, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultChildDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_AgeBetween17And65()
        {
            var r = new TicketRequest { Age = 41, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(BasePrice, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_AgeBetween65And120()
        {
            var r = new TicketRequest { Age = 70, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultPensionerDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return240_StudentAgeBetween18And25()
        {
            var r = new TicketRequest { Age = 20, IsStudent = true, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultStudentDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_StudentBetween26And65()
        {
            var r = new TicketRequest { Age = 26, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(BasePrice, calc.CalculatePrice(r));
        }

        //Скидка дня
        [Fact]
        public void CalculatePrice_Return210_Wednesday()
        {
            var r = new TicketRequest { Age = 41, IsStudent = false, IsVip = false, Day = DayOfWeek.Wednesday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultWednesdayDiscount, calc.CalculatePrice(r));
        }

        //Скидка времени
        [Fact]
        public void CalculatePrice_Return255_MorningBefore12()
        {
            var r = new TicketRequest { Age = 41, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(10.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultMorningDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_SessionAt12NoMorningDiscount()
        {
            var r = new TicketRequest { Age = 41, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(12.00) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(BasePrice, calc.CalculatePrice(r));
        }

        //Вип скидки
        [Fact]
        public void CalculatePrice_Return0_VipUnder6()
        {
            var r = new TicketRequest { Age = 5, IsStudent = false, IsVip = true, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultFreeChildUnder6, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return600_Vip()
        {
            var r = new TicketRequest { Age = 41, IsStudent = false, IsVip = true, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultVipMultiplier, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return300_VipAndBetween65And120()
        {
            var r = new TicketRequest { Age = 70, IsStudent = false, IsVip = true, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultVipAfterPensionerDiscount, calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_Return480_VipAndStudentBetween18And25()
        {
            var r = new TicketRequest { Age = 20, IsStudent = true, IsVip = true, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultVipAfterStudentDiscount, calc.CalculatePrice(r));
        }

        //Комбинирование скидок
        [Fact]
        public void CalculatePrice_Return210_StudentAndWednesday()
        {
            var r = new TicketRequest { Age = 20, IsStudent = true, IsVip = false, Day = DayOfWeek.Wednesday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultWednesdayDiscount, calc.CalculatePrice(r));  //макс.скидка(20, 30) =  30
        }

        [Fact]
        public void CalculatePrice_Return240_StudentAndMorning()
        {
            var r = new TicketRequest { Age = 20, IsStudent = true, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(10.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultStudentDiscount, calc.CalculatePrice(r));  //макс.скидка(15, 20) = 20
        }

        [Fact]
        public void CalculatePrice_Return180_Under6AndWednesday()
        {
            var r = new TicketRequest { Age = 6, IsStudent = false, IsVip = false, Day = DayOfWeek.Wednesday, SessionTime = TimeSpan.FromHours(14.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultChildDiscount, calc.CalculatePrice(r));  //макс.скидка(30, 40) = 40
        }

        [Fact]
        public void CalculatePrice_Return150_Between65And120AndMorning()
        {
            var r = new TicketRequest { Age = 70, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(10.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultPensionerDiscount, calc.CalculatePrice(r));  //макс.скидка(15, 50) = 50
        }

        [Fact]
        public void CalculatePrice_Return420_VipStudentWednesdayMorning()
        {
            var r = new TicketRequest { Age = 20, IsStudent = true, IsVip = true, Day = DayOfWeek.Wednesday, SessionTime = TimeSpan.FromHours(10.41) };
            var calc = new TicketPriceCalculator();
            Assert.Equal(ResultVipAfterWednesdayDiscount, calc.CalculatePrice(r));  //(макс.скидка(20, 30) = 30) + вип
        }

        //Обработка исключений
        [Fact]
        public void CalculatePrice_ThrowArgumentNullException_RequestIsNull()
        {
            TicketRequest r = null;
            TicketPriceCalculator calc = new();
            Assert.Throws<ArgumentNullException>(() => calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_ThrowArgumentOutOfRangeException_AgeNegative()
        {
            TicketRequest r = new TicketRequest { Age = -1, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(11.00) };
            TicketPriceCalculator calc = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.CalculatePrice(r));
        }

        [Fact]
        public void CalculatePrice_ThrowArgumentOutOfRangeException_AgeOver120()
        {
            TicketRequest r = new TicketRequest { Age = 121, IsStudent = false, IsVip = false, Day = DayOfWeek.Monday, SessionTime = TimeSpan.FromHours(11.00) };
            TicketPriceCalculator calc = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => calc.CalculatePrice(r));
        }

    }
}