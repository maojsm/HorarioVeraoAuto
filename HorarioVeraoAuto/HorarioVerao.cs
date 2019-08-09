using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorarioVeraoAuto
{
    public class HorarioVerao
    {
        public static DateTime ObterInicioHorarioVerao(Int32 year)
        {
            // terceiro domingo de outubro
            DateTime primeiroDeOutubro = new DateTime(year, 10, 1);
            DateTime primeiroDomingoDeOutubro = primeiroDeOutubro.AddDays((7 - (Int32)primeiroDeOutubro.DayOfWeek) % 7);
            DateTime terceiroDomingoDeOutubro = primeiroDomingoDeOutubro.AddDays(14);
            return terceiroDomingoDeOutubro;
        }

        public static DateTime ObterFimHorarioVerao(Int32 year)
        {
            DateTime primeiroDeFevereiro = new DateTime(year + 1, 2, 1);
            DateTime primeiroDomingoDeFevereiro = primeiroDeFevereiro.AddDays((7 - (Int32)primeiroDeFevereiro.DayOfWeek) % 7);
            DateTime terceiroDomingoDeFevereiro = primeiroDomingoDeFevereiro.AddDays(14);

            if (terceiroDomingoDeFevereiro != ObterDomingoDeCarnaval(year))
            {
                // terceiro domingo de fevereiro
                return terceiroDomingoDeFevereiro;
            }
            else
            {
                // uma semana depois do terceiro domingo de fevereiro
                return terceiroDomingoDeFevereiro.AddDays(7);
            }
        }

        public static DateTime ObterDomingoDePascoa(int year)
        {
            Int32 a = year % 19;
            Int32 b = year / 100;
            Int32 c = year % 100;
            Int32 d = b / 4;
            Int32 e = b % 4;
            Int32 f = (b + 8) / 25;
            Int32 g = (b - f + 1) / 3;
            Int32 h = (19 * a + b - d - g + 15) % 30;
            Int32 i = c / 4;
            Int32 k = c % 4;
            Int32 L = (32 + 2 * e + 2 * i - h - k) % 7;
            Int32 m = (a + 11 * h + 22 * L) / 451;
            Int32 month = (h + L - 7 * m + 114) / 31;
            Int32 day = ((h + L - 7 * m + 114) % 31) + 1;
            return new DateTime(year, month, day);
        }

        public static DateTime ObterDomingoDeCarnaval(int year)
        {
            return ObterDomingoDePascoa(year).AddDays(-49);
        }

    }
}
