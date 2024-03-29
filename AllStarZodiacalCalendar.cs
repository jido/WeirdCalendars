﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WeirdCalendars {
    public class AllStarZodiacalCalendar : WeirdCalendar {
 
        public override string Author => "Denis Bredelet";
        public override Uri Reference => new Uri("https://calendars.fandom.com/wiki/All_Star_Zodiacal_Calendar");

        protected override DateTime SyncDate => new DateTime(2024, 3, 27);
        protected override int SyncOffset => 0;

        public override int GetDaysInMonth(int year, int month, int era) {
            ValidateDateParams(year, month, era);
            switch(month) {
                case 2:
                case 3:
                case 5:
                case 6:
                    return 31;
                case 4:
                    return 32;
                case 10:
                    return 29;
                case 12:
                    return IsLeapYear(year) ? 31 : 30;
                default:
                    return 30;
            }
        }

        public override bool IsLeapYear(int year, int era) {
            ValidateDateParams(year, era);
            int s = year % 138;
            int l = year % 1100;
            return s % 4 == 0 && s != 136 && l != 1098;
        }

        public override bool IsLeapDay(int year, int month, int day, int era) {
            ValidateDateParams(year, month, day, era);
            return month == 12 && day == 31;
        }

        internal override void CustomizeDTFI(DateTimeFormatInfo dtfi) {
            SetNames(dtfi, new string[] { "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn", "Aquarius", "Pisces", "" });
        }

    }
}
