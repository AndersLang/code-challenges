using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessHourCounter;

namespace BusinessHourCounterTest
{
    [TestClass]
    public class CounterTest
    {
        Counter counter = new Counter();

        [TestMethod]
        public void test_calculation_of_hours_within_the_same_date_is_done_correct()
        {
            DateTime dt1 = DateTime.Parse("2018-01-03T04:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-01-03T18:00:00.123123+0200");
            string res = "12.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_calculation_of_hours_within_the_same_business_day_is_done_correct()
        {
            DateTime dt1 = DateTime.Parse("2018-01-03T08:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-01-03T12:00:00.123123+0200");
            string res = "4.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_calc_of_hours_with_less_than_a_minutes_difference_is_done_correctly()
        {
            DateTime dt1 = DateTime.Parse("2018-01-03T06:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-01-03T06:00:45.123123+0200");
            string res = "0.0125";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_calc_of_hours_with_a_second_in_difference_is_done_correctly()
        {
            DateTime dt1 = DateTime.Parse("2018-01-03T06:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-01-03T06:00:01.123123+0200");
            string res = "0.0002777777777777778";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_calc_of_days_before_and_after_christmas_eve()
        {
            DateTime dt1 = DateTime.Parse("2018-12-23T02:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-12-26T22:00:01.123123+0200");
            string res = "24.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_one_full_businessdays()
        {
            DateTime dt1 = DateTime.Parse("2018-07-23T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-23T22:00:01.123123+0200");
            string res = "12.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_a_few_hours_on_the_same_date()
        {
            DateTime dt1 = DateTime.Parse("2018-07-11T15:29:03.837000+0200");
            DateTime dt2 = DateTime.Parse("2018-07-12T06:01:41.874000+0200");
            string res = "2.5438888888888886";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_two_full_businessdays()
        {
            DateTime dt1 = DateTime.Parse("2018-07-23T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-24T22:00:01.123123+0200");
            string res = "24.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_three_full_businessdays()
        {
            DateTime dt1 = DateTime.Parse("2018-07-23T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-25T22:00:01.123123+0200");
            string res = "36.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_four_full_businessdays()
        {
            DateTime dt1 = DateTime.Parse("2018-07-23T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-26T22:00:01.123123+0200");
            string res = "48.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_five_full_businessdays()
        {
            DateTime dt1 = DateTime.Parse("2018-07-23T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-27T22:00:01.123123+0200");
            string res = "60.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_two_full_businessdays_with_weekend_in_middle()
        {
            DateTime dt1 = DateTime.Parse("2018-07-13T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-16T18:00:00.123123+0200");
            string res = "24.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_one_full_businessday_with_weekend_in_middle_and_t1_after_office_hours()
        {
            DateTime dt1 = DateTime.Parse("2018-07-13T19:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-16T18:00:00.123123+0200");
            string res = "12.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_two_full_businessday_with_weekend_in_middle_and_t1_after_office_hours()
        {
            DateTime dt1 = DateTime.Parse("2018-07-13T19:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-17T18:00:00.123123+0200");
            string res = "24.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_one_full_businessday_and_t1_after_office_hours()
        {
            DateTime dt1 = DateTime.Parse("2018-07-16T19:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-17T18:00:00.123123+0200");
            string res = "12.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_one_full_businessday_neither_first_or_last_day_has_valid_office_hours()
        {
            DateTime dt1 = DateTime.Parse("2018-07-16T22:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-18T02:00:00.123123+0200");
            string res = "12.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_two_full_businessdays_with_last_timestamp_on_weekday()
        {
            DateTime dt1 = DateTime.Parse("2018-07-29T05:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-31T18:00:00.123123+0200");
            string res = "24.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_neither_timestamp_is_in_office_hours_with_night_apart()
        {
            DateTime dt1 = DateTime.Parse("2018-07-16T19:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-17T04:00:00.123123+0200");
            string res = "0.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_neither_timestamp_is_in_office_hours_same_evening()
        {
            DateTime dt1 = DateTime.Parse("2018-07-16T19:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-16T22:00:00.123123+0200");
            string res = "0.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_neither_timestamp_is_in_office_hours_same_morning()
        {
            DateTime dt1 = DateTime.Parse("2018-07-16T02:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2018-07-16T03:00:00.123123+0200");
            string res = "0.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }

        [TestMethod]
        public void test_time_span_including_holidays_weekends_and_turn_of_the_month()
        {
            ;
            DateTime dt1 = DateTime.Parse("2018-12-22T02:00:00.123123+0200");
            DateTime dt2 = DateTime.Parse("2019-01-03T20:00:00.123123+0200");
            string res = "84.0";
            Assert.AreEqual(res, counter.getHoursBetweenTimestamps(dt1, dt2));
        }
    }
}
