﻿using System.Linq;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TKPartnersV2.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.NewsRepo.Any())
            {
                context.NewsRepo.AddRange(
                    new News
                    {
                        Name = "Помічник юриста",
                        Author = "",
                        Date = new DateTime(2016, 8, 1),
                        Description = "Адвокатське об'єднання T.K.Partners запрошує на роботу Помічника юриста. Якщо Ви випускник юридичного факультету або студент останніх курсів навчання, маєте нестримне бажання вчитися практичній роботі та набувати досвід - чекаємо Ваше резюме."
                    },
                    new News
                    {
                        Name = "Нове в управлінні об'єктами державної та комунальної власності",
                        Author = "Ольга Фрейдун",
                        Date = new DateTime(2016, 7, 7),
                        Description = "Адвокатське об'єднання T.K.Partners запрошує на роботу Помічника юриста. Якщо Ви випускник юридичного факультету або студент останніх курсів навчання, маєте нестримне бажання вчитися практичній роботі та набувати досвід - чекаємо Ваше резюме."
                    },
                    new News
                    {
                        Name = "Збільшення ставок судового збору",
                        Author = "Ольга Фрейдун",
                        Date = new DateTime(2016, 7, 7),
                        Description = "Звертаємо увагу, що 01 вересня 2015 року набирають чинності зміни до Закону України «Про судовий збір», відповідно до яких змінюються ставки судового збору.Зокрема за подання до господарського суду позовної заяви майнового характеру встановлюється максимальний розмір ставки судового збору — 150 мінімальних заробітних плат,у той час як сьогодні максимальний розмір ставки обмежений 60 - ти мінімальними зарплатами.Також буде збільшено розмір судового збору за подання апеляційної скарги на рішення господарського суду до — 110, а касаційної до  — 120 відсотків ставки, що підлягала при сплаті позовної заяви,замість 50 та 70 відсотків відповідно,встановлених діючою редакцією закону.За подання до адміністративного суду позову майнового характеру юридичні особи сплачуватимуть 1,5 відсотки ціни позову, при цьому максимальний розмір ставки в адміністративних справах для юридичних осіб законом не обмежуватиметься, у той час як відповідно до діючої редакції закону максимальний розмір ставки судового збору в адміністративних справах за подання позову майнового характеру, становить чотири мінімальні зарплати.З огляду на наведене,рекомендуємо розглянути питання подання до 01.09.2015 року всіх можливих і необхідних позовних заяв, апеляційних чи касаційних скарг стосовно стягнення заборгованості договорами, оскарження рішень органів державної влади та / або місцевого самоврядування(особливо майнового характеру) тощо."
                    }
                 );
                context.SaveChanges();
            }
        }
    }
}

