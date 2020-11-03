using Insurance_Company.Models;
using System;
using System.Linq;

namespace Insurance_Company.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InsuranceCompanyContext context)
        {
            context.Database.EnsureCreated();
            if (context.Klienty.Any())
            {
                return;
            }
          
            var Klient = new Klienty[]
                //Klient[]
            {
            new
Klienty{Fio="Ivan Yasenev",
        DataRozhdeniya=DateTime.Parse("1975-09-05"),
        Pol="", Adres="", Telefon="", PasportnyeDannye="", KodGruppy=1},
            new
Klienty{Fio="Anna Alonso",
        DataRozhdeniya=DateTime.Parse("1986-12-25"),
        Pol="", Adres="", Telefon="", PasportnyeDannye="", KodGruppy=1},
/*            new
Klienty{FirstMidName="Peter",LastName="Nikitin",DataRozhdeniya=DateTime.Parse("1974-04-01")},
            new
Klienty{FirstMidName="Michael",LastName="Barzdukas",DataRozhdeniya=DateTime.Parse("1988-07-26")},
            new
Klienty{FirstMidName="Maria",LastName="Scriabina",DataRozhdeniya=DateTime.Parse("1968-09-01")},
            new
Klienty{FirstMidName="Alena",LastName="Arsenieva",DataRozhdeniya=DateTime.Parse("1983-03-11")},
            new
Klienty{FirstMidName="Juliana",LastName="Kashnikova",DataRozhdeniya=DateTime.Parse("1990-09-20")},
            new
Klienty{FirstMidName="Alexander",LastName="Pugachev",DataRozhdeniya=DateTime.Parse("1977-12-31")}
*/            };
            foreach (Klienty s in Klient)
            {
                context.Klienty.Add(s);
            }
            context.SaveChanges();
 /*           var Riski = new Risk[]
            {
            new Risk{KodRiska=123,Naimenovanie="Fire",Opisanie="Risk Fire",SrednyayaVeroyatnost=0,6},
            new Risk{KodRiska=342,Naimenovanie="Flood",Opisanie="Risk Flood",SrednyayaVeroyatnost=0,3},
            new Risk{KodRiska=743,Naimenovanie="Hijacking",Opisanie="Risk Hijacking",SrednyayaVeroyatnost=0,8},
            new Risk{KodRiska=653,Naimenovanie="Crash",Opisanie="Risk Crash",SrednyayaVeroyatnost=0,4},
            new Risk{KodRiska=232,Naimenovanie="Landslide",Opisanie="Risk Landslide",SrednyayaVeroyatnost=0,1},
            new Risk{KodRiskaD=345,Naimenovanie="Explosion",Opisanie="Risk Explosion",SrednyayaVeroyatnost=0,1},
            new Risk{KodRiska=221,Naimenovanie="Hurricane",Opisanie="Risk Hurricane",SrednyayaVeroyatnost=0,1}
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
            var enrollments = new Enrollment[]
            {
            new Enrollment{StudentID=1,CourseID=1050,Grade=Grade.A},
            new Enrollment{StudentID=1,CourseID=4022,Grade=Grade.C},
            new Enrollment{StudentID=1,CourseID=4041,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=1045,Grade=Grade.B},
            new Enrollment{StudentID=2,CourseID=3141,Grade=Grade.F},
            new Enrollment{StudentID=2,CourseID=2021,Grade=Grade.F},
            new Enrollment{StudentID=3,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=1050},
            new Enrollment{StudentID=4,CourseID=4022,Grade=Grade.F},
            new Enrollment{StudentID=5,CourseID=4041,Grade=Grade.C},
            new Enrollment{StudentID=6,CourseID=1045},
            new Enrollment{StudentID=7,CourseID=3141,Grade=Grade.A},
            };
            foreach (Enrollment e in enrollments)
            {
                context.Enrollments.Add(e);
            }
            context.SaveChanges();
     */   }
    }
}
