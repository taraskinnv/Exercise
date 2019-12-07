using System;
using System.Collections.Generic;
using System.Text;

namespace exercise_6
{
    class Converter
    {
        private Double usd;
        private Double eur;
        private Double rub;
        public Converter(Double usd, Double eur, Double rub)
        {
            this.usd = usd;
            this.eur = eur;
            this.rub = rub;
        }

        public double ConvertUsdUah(double sumUsd)
        {
            return usd * sumUsd;
        }
        public double ConvertEurUah(double sumEur)
        {
            return eur * sumEur;
        }
        public double ConvertRubUah(double sumRub)
        {
            return rub * sumRub;
        }

        public double ConvertUanUsd(double sumUah)
        {
            return sumUah / usd;
        }

        public double ConvertUahEur(double sumUah)
        {
            return sumUah / eur;
        }

        public double ConvertUahRub(double sumUah)
        {
            return sumUah / rub;
        }
    }
}
