using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using SplashTrainer.Models;

namespace SplashTrainer.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        // Tabela przechowująca dziennik aktywności
        public DbSet<ActivityLog> ActivityLogs { get; set; }

        // Tabela łącząca plany z ćwiczeniami
        public DbSet<PlanExercise> PlanExercises { get; set; }

        // Tabela przechowująca ćwiczenia pływackie
        public DbSet<SwimmingExercise> SwimmingExercises { get; set; }

        // Tabela przechowująca plany treningowe
        public DbSet<SwimmingPlan> SwimmingPlans { get; set; }

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SwimmingExercise>().HasData(

                //////////////////////////////////////////////// Grzbiet
                // Nogi
                new SwimmingExercise
                {
                    Id = 10,
                    IsDefault = true,
                    Name = "Praca nóg z deską",
                    Distance = 50,
                    Category = "Nogi",
                    Style = "Grzbiet",
                    Level = "Początkujący",
                    Description = "Deskę trzymaj na wyskości ud, na prostych rękach. Skup się na stabilnym tempie i równm ułożeniu bioder."
                },
    new SwimmingExercise
    {
        Id = 11,
        IsDefault = true,
        Name = "Naprzemienne kopnięcia bez deski",
        Distance = 100,
        Category = "Nogi",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Utrzymuj równą pracę nóg na całym dystansie."
    },
    new SwimmingExercise
    {
        Id = 12,
        IsDefault = true,
        Name = "Wysokie kopnięcia nóg",
        Distance = 100,
        Category = "Nogi",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Pamiętaj o minimalnie ugiętych kolanach i o tym żeby nie wychodziły nad taflę wody oraz o poprawnie ułożonych biodrach."
    },
    new SwimmingExercise
    {
        Id = 13,
        IsDefault = true,
        Name = "Kopnięcia nóg z rękoma w strzałce",
        Distance = 100,
        Category = "Nogi",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Złącz ręce za głową w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby kolana nie wychodziły nad wodę."
    },
    new SwimmingExercise
    {
        Id = 14,
        IsDefault = true,
        Name = "Praca jedną nogą",
        Distance = 50,
        Category = "Nogi",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Skup się na izolowaniu jednej nogi przed 25m."
    },

    // Ręce
    new SwimmingExercise
    {
        Id = 15,
        IsDefault = true,
        Name = "Praca rąk z pullboyem",
        Distance = 50,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Skup się na technice naprzemiennej pracy ramion."
    },
    new SwimmingExercise
    {
        Id = 16,
        IsDefault = true,
        Name = "Naprzemienne praca rąk",
        Distance = 100,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Utrzymuj symetryczną pracę rąk oraz stabilny korpus. Pamiętaj aby dłoń wkładać do wody zaczynając od małego palca, a wyciągać z wody zaczynając od kciuka."
    },
    new SwimmingExercise
    {
        Id = 17,
        IsDefault = true,
        Name = "Naprzemiennie z klaśnięciem",
        Distance = 100,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Zacznij od ruchu jedną ręką - drugą trzymaj wzdłuż ciała. Po wykonaniu ruchu, klaśnij delikatnie nad wodą, nad nogami. Trzymaj wyprostowane ręce. Następnie powtórz po ruchu drugiej ręki."
    },
    new SwimmingExercise
    {
        Id = 18,
        IsDefault = true,
        Name = "Ćwiczenie na precyzję wejścia rąk",
        Distance = 50,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Koncentruj się na delikatnym i precyzyjnym wejściu dłoni do wody - od małego palca. Wyjście zaczyna się od kciuka. Pamiętaj, aby nie uginać łokci."
    },
    new SwimmingExercise
    {
        Id = 19,
        IsDefault = true,
        Name = "Praca jedną ręką",
        Distance = 100,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Pracuj jedną ręką prze 50m, utrzymując stabilną pozycję ciała."
    },

    // Koordynacja
    new SwimmingExercise
    {
        Id = 20,
        IsDefault = true,
        Name = "Równoczesna praca rąk i nóg",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Pamiętaj o synchronizacji pracy rąk i nóg."
    },
    new SwimmingExercise
    {
        Id = 21,
        IsDefault = true,
        Name = "Dokładanka z rękoma wzdłuż ciała",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wzdłuż bioder.Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 22,
        IsDefault = true,
        Name = "Dokładanka z rękoma wzdłuż ciała + zatrzymanie",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je przy biodrach na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 23,
        IsDefault = true,
        Name = "Zegar",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Umieść jedą rękę prostą za głową, a drugą wzdłuż ciała. Wykonuj ruchy naprzemiennie. Po każdym ruchu zatrzymanie rąk na 4 sekundy. Zachowaj pełną kontrolę nad pracą nóg i rąk."
    },
    new SwimmingExercise
    {
        Id = 24,
        IsDefault = true,
        Name = "Praca obu rąk na raz",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Utrzymuj biodra wysoko i spęty brzuch, podczas przekładania obu rąk. Dostosuj tempo do wydłużonych ruchów rąk."
    },

    // Wytrzymałość
    new SwimmingExercise
    {
        Id = 25,
        IsDefault = true,
        Name = "Pływanie w równym tempie",
        Distance = 200,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Skup się na równomiernym oddechu i rytmie."
    },
    new SwimmingExercise
    {
        Id = 26,
        IsDefault = true,
        Name = "Wytrzymałość na długim dystansie",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Płyń na 75% możliwości przez 100m, odpoczywaj przez 20 sekund."
    },
    new SwimmingExercise
    {
        Id = 27,
        IsDefault = true,
        Name = "Serie z kontrolą oddechu",
        Distance = 100,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Wdychaj co trzeci cykl, utrzymując stabilne tempo."
    },
    new SwimmingExercise
    {
        Id = 28,
        IsDefault = true,
        Name = "Naprzemienne tempo",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Zmieniaj tempo co 25m, przechodząc z szybkiego na wolne."
    },
    new SwimmingExercise
    {
        Id = 29,
        IsDefault = true,
        Name = "Wydłużone dystanse w równym rytmie",
        Distance = 250,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Płyń w stałym tempie, kontrolując oddech i pracę ciała."
    },

    // Szybkość
    new SwimmingExercise
    {
        Id = 30,
        IsDefault = true,
        Name = "Sprint na krótkim dystansie",
        Distance = 50,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Daj z siebie wszystko na krótkim odcinku."
    },
    new SwimmingExercise
    {
        Id = 31,
        IsDefault = true,
        Name = "Naprzemienne sprinty",
        Distance = 75,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Zmieniaj intensywność co 25m. Zacznij od średniego tempa."
    },
    new SwimmingExercise
    {
        Id = 32,
        IsDefault = true,
        Name = "Starty z nawrotem",
        Distance = 100,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Ćwicz szybki start i dynamiczne nawroty."
    },
    new SwimmingExercise
    {
        Id = 33,
        IsDefault = true,
        Name = "Skrócone serie sprintów",
        Distance = 25,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Maksymalna intensywność na każdym 25m."
    },
    new SwimmingExercise
    {
        Id = 34,
        IsDefault = true,
        Name = "Długie sprinty",
        Distance = 100,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Utrzymuj najwyższą intensywność przez cały dystans."
    },

    ////////////////////////////////////////////////////////////// Kraul
    // Nogi
    new SwimmingExercise
    {
        Id = 35,
        IsDefault = true,
        Name = "Naprzemienne kopnięcia z deską",
        Distance = 50,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Utrzymuj biodra na powierzchni wody, staraj się trzymać je na jednym poziomie."
    },
    new SwimmingExercise
    {
        Id = 36,
        IsDefault = true,
        Name = "Naprzemienne kopnięcia bez deski",
        Distance = 100,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Utrzymuj równą pracę nóg na całym dystansie."
    },
    new SwimmingExercise
    {
        Id = 37,
        IsDefault = true,
        Name = "Wysokie kopnięcia nóg",
        Distance = 100,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Wykonuj energiczne i szybkie kopnięcia. Pamiętaj o minimalnie ugiętych kolanach i o poprawnie ułożonych biodrach."
    },
    new SwimmingExercise
    {
        Id = 38,
        IsDefault = true,
        Name = "Kopnięcia nóg z rękoma w strzałce",
        Distance = 150,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Złącz ręce za głową w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby stopy nie wychodziły nad wodę."
    },
    new SwimmingExercise
    {
        Id = 39,
        IsDefault = true,
        Name = "Praca jedną nogą",
        Distance = 150,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Skup się na izolowaniu jednej nogi przed 25m."
    },

    // Ręce
    new SwimmingExercise
    {
        Id = 40,
        IsDefault = true,
        Name = "Praca rąk z pullboyem",
        Distance = 50,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Trzymaj biodra stabilnie i skup się na wiosłowaniu."
    },
    new SwimmingExercise
    {
        Id = 41,
        IsDefault = true,
        Name = "Naprzemienne praca rąk z deską",
        Distance = 100,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Wykonuj ruch jedną ręką. Drugą trzymaj deskę. Utrzymuj stabilny korpus."
    },
    new SwimmingExercise
    {
        Id = 42,
        IsDefault = true,
        Name = "Praca jedną ręką",
        Distance = 100,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Skup się na pracy jedną ręką przez 50m. Możesz użyć deski."
    },
    new SwimmingExercise
    {
        Id = 43,
        IsDefault = true,
        Name = "Synchronizacja rąk z oddechem",
        Distance = 150,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Zwróć uwagę na synchronizację ruchów z regularnym oddechem."
    },
    new SwimmingExercise
    {
        Id = 44,
        IsDefault = true,
        Name = "Wydłużenie cykli pracy rąk",
        Distance = 150,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Sięgaj ręką jak najdalej, odkręcaj bark. Koncentruj się na pełnym zakresie ruchu i efektywności pracy rąk."
    },

    // Koordynacja
    new SwimmingExercise
    {
        Id = 45,
        IsDefault = true,
        Name = "Synchronizacja rąk i nóg",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Dostosuj tempo nóg do ruchów rąk."
    },
    new SwimmingExercise
    {
        Id = 46,
        IsDefault = true,
        Name = "Dokładanka z rękoma wyprostowanymi z przodu",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wyprostowana z przodu obok drugiej ręki.Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 47,
        IsDefault = true,
        Name = "Dokładanka z rękoma wyprostowanymi z przodu + zatrzymanie",
        Distance = 50,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je z przodu na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 48,
        IsDefault = true,
        Name = "Zegar",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Umieść jedą rękę prostą za głową, a drugą wzdłuż ciała. Wykonuj ruchy naprzemiennie. Po każdym ruchu zatrzymanie rąk na 4 sekundy. Zachowaj pełną kontrolę nad pracą nóg i rąk."
    },
    new SwimmingExercise
    {
        Id = 49,
        IsDefault = true,
        Name = "Zegar + klepnięcie",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Umieść jedą rękę prostą za głową, a drugą wzdłuż ciała. Wykonuj ruchy naprzemiennie. Po każdym ruchu, klepnij ręką w wodę. Zachowaj pełną kontrolę nad pracą nóg i rąk."
    },

    // Wytrzymałość
    new SwimmingExercise
    {
        Id = 50,
        IsDefault = true,
        Name = "Pływanie w równym tempie",
        Distance = 200,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Skup się na utrzymaniu równomiernego oddechu."
    },
    new SwimmingExercise
    {
        Id = 51,
        IsDefault = true,
        Name = "Wytrzymałość z krótkimi przerwami",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Odpoczywaj 15 sekund po każdym dystansie 50m."
    },
    new SwimmingExercise
    {
        Id = 52,
        IsDefault = true,
        Name = "Serie z kontrolą oddechu",
        Distance = 100,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Wdychaj co trzeci ruch ramion."
    },
    new SwimmingExercise
    {
        Id = 53,
        IsDefault = true,
        Name = "Naprzemienne tempo co 25m",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Przechodź między szybkim a wolnym tempem."
    },
    new SwimmingExercise
    {
        Id = 54,
        IsDefault = true,
        Name = "Długie dystanse w równym rytmie",
        Distance = 250,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Utrzymuj spokojny oddech i równomierne tempo."
    },

    // Szybkość
    new SwimmingExercise
    {
        Id = 55,
        IsDefault = true,
        Name = "Sprinty na krótkim dystansie",
        Distance = 50,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Odpoczywaj 30 sekund między każdym sprintem."
    },
    new SwimmingExercise
    {
        Id = 56,
        IsDefault = true,
        Name = "Naprzemienne sprinty i pływanie luźne",
        Distance = 75,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Zmieniaj intensywność co 25m."
    },
    new SwimmingExercise
    {
        Id = 57,
        IsDefault = true,
        Name = "Dynamiczne starty z nawrotem",
        Distance = 100,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Trenuj dynamiczne starty i nawroty z maksymalną intensywnością."
    },
    new SwimmingExercise
    {
        Id = 58,
        IsDefault = true,
        Name = "Sprint",
        Distance = 50,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Utrzymuj najwyższą intensywność na całym dystansie."
    },
    new SwimmingExercise
    {
        Id = 59,
        IsDefault = true,
        Name = "Maksymalna prędkość na dłuższym dystansie",
        Distance = 100,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Staraj się utrzymać maksymalne tempo przez cały dystans."
    },

    /////////////////////////////////////////////////////////////////////////////
    // Żaba
    // Nogi
    new SwimmingExercise
    {
        Id = 60,
        IsDefault = true,
        Name = "Naprzemienne kopnięcia z deską",
        Distance = 50,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Skup się na szerokim ruchu nóg, przypominającym żabę. Pamiętaj aby kolana nie były za daleko od siebie."
    },
    new SwimmingExercise
    {
        Id = 61,
        IsDefault = true,
        Name = "Naprzemienne kopnięcia nóg + wyleżenie",
        Distance = 100,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Po każdym ruchu, trzymaj złączone nogi, dopkóki nie stracisz całej prędkości. Pamiętaj o dokładnym prostowaniu nóg po każdym ruchu."
    },
    new SwimmingExercise
    {
        Id = 62,
        IsDefault = true,
        Name = "Małe i duże kółeczka",
        Distance = 100,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Wykonuj naprzemiennie mały okrąg nogami, a następnie pełen cykl - duży okrąg."
    },
    new SwimmingExercise
    {
        Id = 63,
        IsDefault = true,
        Name = "Kopnięcia nóg z rękoma w strzałce",
        Distance = 150,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Złącz ręce za głową w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby stopy nie wychodziły nad wodę."
    },
    new SwimmingExercise
    {
        Id = 64,
        IsDefault = true,
        Name = "Praca jedną nogą",
        Distance = 150,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Skup się na izolowaniu jednej nogi przed 25m."
    },

    // Ręce
    new SwimmingExercise
    {
        Id = 65,
        IsDefault = true,
        Name = "Ruchy rąk z pullboyem",
        Distance = 50,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Trzymaj nogi stabilnie i skup się na ruchu rąk."
    },
    new SwimmingExercise
    {
        Id = 66,
        IsDefault = true,
        Name = "Praca jedną ręką na zmianę",
        Distance = 100,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Skup się na pełnym zakresie ruchu jednej ręki."
    },
    new SwimmingExercise
    {
        Id = 67,
        IsDefault = true,
        Name = "Synchronizacja rąk z oddechem",
        Distance = 100,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Dostosuj rytm rąk do odpowiedniego momentu oddechu."
    },
    new SwimmingExercise
    {
        Id = 68,
        IsDefault = true,
        Name = "Żabo-Kraul",
        Distance = 150,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Skup się na pracy rąk. Wykomując nogi do kraula, łatwiej skupisz się na technice pracy rąk do żaby."
    },
    new SwimmingExercise
    {
        Id = 69,
        IsDefault = true,
        Name = "Wydłużone cykle pracy rąk",
        Distance = 150,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Skup się na spokojnym i pełnym zakresie ruchu."
    },

    // Koordynacja
    new SwimmingExercise
    {
        Id = 70,
        IsDefault = true,
        Name = "Synchronizacja nóg i rąk",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Dostosuj rytm nóg do ruchu rąk."
    },
    new SwimmingExercise
    {
        Id = 71,
        IsDefault = true,
        Name = "Dokładanka z rękoma wyprostowanymi z przodu",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wyprostowana z przodu obok drugiej ręki.Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 72,
        IsDefault = true,
        Name = "Dokładanka z rękoma wyprostowanymi z przodu + zatrzymanie",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je z przodu na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 73,
        IsDefault = true,
        Name = "Pełen cykl + dodatkowe kopnięcie",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowe mocne kopnięcie nogami."
    },
    new SwimmingExercise
    {
        Id = 74,
        IsDefault = true,
        Name = "Pełen cykl + dodatkowy ruch rękoma",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowy ruch rękoma."
    },

    // Wytrzymałość
    new SwimmingExercise
    {
        Id = 75,
        IsDefault = true,
        Name = "Równomierne tempo na dystansie",
        Distance = 200,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Skup się na utrzymaniu stałego tempa przez cały dystans."
    },
    new SwimmingExercise
    {
        Id = 76,
        IsDefault = true,
        Name = "Wytrzymałość z krótkimi przerwami",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Płyń 50m, odpoczywaj 15 sekund."
    },
    new SwimmingExercise
    {
        Id = 77,
        IsDefault = true,
        Name = "Długie dystanse w równym rytmie",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Utrzymuj kontrolę nad oddechem i tempem."
    },
    new SwimmingExercise
    {
        Id = 78,
        IsDefault = true,
        Name = "Żabo-Nurek",
        Distance = 25,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Spróbuj przepłynąć żabą 25m pod wodą."
    },
    new SwimmingExercise
    {
        Id = 79,
        IsDefault = true,
        Name = "Naprzemienne tempo co 50",
        Distance = 250,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Zmieniaj tempo co 50m, przechodząc z wolnego na szybkie."
    },

    // Szybkość
    new SwimmingExercise
    {
        Id = 80,
        IsDefault = true,
        Name = "Sprinty z przerwami",
        Distance = 50,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Daj z siebie wszystko przez 50m, odpoczywaj 30 sekund."
    },
    new SwimmingExercise
    {
        Id = 81,
        IsDefault = true,
        Name = "Dynamiczne starty z nawrotem",
        Distance = 100,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Ćwicz szybkie starty i nawroty na krótkim dystansie."
    },
    new SwimmingExercise
    {
        Id = 82,
        IsDefault = true,
        Name = "Naprzemienne tempo sprintów",
        Distance = 75,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Zmieniaj intensywność co 25m. Szybko / luźno."
    },
    new SwimmingExercise
    {
        Id = 83,
        IsDefault = true,
        Name = "Sprint",
        Distance = 50,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Płyń maksymalnym tempem przez każdy dystans."
    },
    new SwimmingExercise
    {
        Id = 84,
        IsDefault = true,
        Name = "Wydłużone sprinty",
        Distance = 100,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Staraj się utrzymać maksymalne tempo przez cały dystans."
    },

    // Delfin
    // Nogi
    new SwimmingExercise
    {
        Id = 85,
        IsDefault = true,
        Name = "Praca nóg z deską",
        Distance = 50,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Nogi muszą pracować jednocześnie. Skup się na rytmicznej pracy bioder i nóg."
    },
    new SwimmingExercise
    {
        Id = 86,
        IsDefault = true,
        Name = "Kopnięcia nóg na boku",
        Distance = 100,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Połóż się na wyciągniętej ręce z przodu. Drugą trzymaj wzdłuż ciała. Utrzymuj biodra na powierzchni wody."
    },
    new SwimmingExercise
    {
        Id = 87,
        IsDefault = true,
        Name = "Pod wodą + strzałka",
        Distance = 100,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Trzymaj ręce złączone w strzałce. Zrób krótką przerwę każdych 25m. Staraj się przepłynąć pod wodą jak najdłużej."
    },
    new SwimmingExercise
    {
        Id = 88,
        IsDefault = true,
        Name = "Praca nóg + oddech",
        Distance = 150,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Trzymaj ręce wzdłuż ciała. Co 3 kopnięcia nabieraj oddech, bez odrywania rąk."
    },
    new SwimmingExercise
    {
        Id = 89,
        IsDefault = true,
        Name = "Naprzemienne kopnięcia z deski",
        Distance = 150,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Złącz ręce przed sobą w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby stopy nie wychodziły nad wodę."
    },

    // Ręce
    new SwimmingExercise
    {
        Id = 90,
        IsDefault = true,
        Name = "Pół - odepchnięcia pod wodą",
        Distance = 100,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Ułóż ręce proste przed sobą. Delikatnie ugnij nadgarstki i pociągnij prostymi rękoma, aż do lini bioder. Zatrzymaj tam ręce wyprostowane i poczekaj, aż stracisz prędkość. "
    },
    new SwimmingExercise
    {
        Id = 91,
        IsDefault = true,
        Name = "Praca rąk z pullboyem",
        Distance = 50,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Trzymaj nogi stabilnie i skup się na ruchu rąk."
    },

    new SwimmingExercise
    {
        Id = 92,
        IsDefault = true,
        Name = "Praca jedną ręką na zmianę",
        Distance = 100,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Pamiętaj, aby nie uginać ręki pod wodą. Nad wodą przenoś rękę bokiem. Skup się na pełnym zakresie ruchu jednej ręki. Zmieniaj rękę co 25m."
    },
    new SwimmingExercise
    {
        Id = 93,
        IsDefault = true,
        Name = "Kraulo-Delfin",
        Distance = 150,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Skup się na pracy rąk. Wykomując nogi do kraula, łatwiej skupisz się na technice pracy rąk do delfina."
    },
    new SwimmingExercise
    {
        Id = 94,
        IsDefault = true,
        Name = "Dokładanka 1/2",
        Distance = 150,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Wykonuj dokładankę płynąć jeden ruch jedną ręką, na zmianę z drugą."
    },

    // Koordynacja
    new SwimmingExercise
    {
        Id = 95,
        IsDefault = true,
        Name = "Synchronizacja nóg i rąk",
        Distance = 50,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Połącz równomierne ruchy nóg i rąk."
    },
    new SwimmingExercise
    {
        Id = 96,
        IsDefault = true,
        Name = "Dokładanka z rękoma wyprostowanymi z przodu",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wyprostowana z przodu obok drugiej ręki.Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 97,
        IsDefault = true,
        Name = "Dokładanka z rękoma wyprostowanymi z przodu + zatrzymanie",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je z przodu na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl."
    },
    new SwimmingExercise
    {
        Id = 98,
        IsDefault = true,
        Name = "Pełen cykl + dodatkowe kopnięcie",
        Distance = 100,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowe mocne kopnięcie nogami."
    },
    new SwimmingExercise
    {
        Id = 99,
        IsDefault = true,
        Name = "Pełen cykl + dodatkowy ruch rękoma",
        Distance = 150,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowy ruch rękoma."
    },

    // Wytrzymałość
    new SwimmingExercise
    {
        Id = 100,
        IsDefault = true,
        Name = "Pływanie w równym tempie",
        Distance = 100,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Skup się na utrzymaniu stałego rytmu i oddechu."
    },
    new SwimmingExercise
    {
        Id = 101,
        IsDefault = true,
        Name = "Tlenowe z krótkimi przerwami",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Przepłyń 50, odpoczywaj 15 sekund, powtarzaj."
    },
    new SwimmingExercise
    {
        Id = 102,
        IsDefault = true,
        Name = "Długi dystans w stałym tempie",
        Distance = 150,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Utrzymuj równy rytm na długim dystansie."
    },
    new SwimmingExercise
    {
        Id = 103,
        IsDefault = true,
        Name = "Seria z kontrolą oddechu",
        Distance = 100,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Skup się na równomiernym oddechu co trzeci ruch ramion."
    },
    new SwimmingExercise
    {
        Id = 104,
        IsDefault = true,
        Name = "Zmienność tempa na dystansie",
        Distance = 250,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Zmieniając tempo co 50m ( szybko/ wolno). ćwicz kontrolę nad wysiłkiem."
    },

    // Szybkość
    new SwimmingExercise
    {
        Id = 105,
        IsDefault = true,
        Name = "Sprinty 25m",
        Distance = 25,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Daj z siebie wszystko na krótkich dystansach."
    },
    new SwimmingExercise
    {
        Id = 106,
        IsDefault = true,
        Name = "Naprzemienne sprinty i luźne tempo",
        Distance = 75,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Zmieniaj intensywność co 25m, przechodząc od sprintu do luźnego tempa."
    },
    new SwimmingExercise
    {
        Id = 107,
        IsDefault = true,
        Name = "Dynamiczne starty z nawrotem",
        Distance = 50,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Ćwicz szybkie starty i dynamiczne nawroty."
    },
    new SwimmingExercise
    {
        Id = 108,
        IsDefault = true,
        Name = "Sprint 50m",
        Distance = 50,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Utrzymuj maksymalną intensywność przez 50m."
    },
    new SwimmingExercise
    {
        Id = 109,
        IsDefault = true,
        Name = "Sprint na dłuższym dystansie",
        Distance = 100,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Staraj się utrzymać maksymalne tempo przez cały dystans."
    }

    //// dodoatkowe
    ///
    ///grzbiet podtsawa
    ,
    new SwimmingExercise
    {
        Id = 110,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 111,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 112,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 113,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 114,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },


      ///grzbiet zaawansowany
    
    new SwimmingExercise
    {
        Id = 115,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 116,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 117,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 118,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 119,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Grzbiet",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },

    //////////// kraul podstawowy
    ///


    new SwimmingExercise
    {
        Id = 120,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 121,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 122,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 123,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 124,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },

    ////////////// kraul zaawansowany 
    ///

    new SwimmingExercise
    {
        Id = 125,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 126,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 127,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 128,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 129,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Kraul",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    ////////////// zaba podstaowowoa 



    new SwimmingExercise
    {
        Id = 130,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 131,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 132,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 133,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 134,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },

    ////////////// zaba zaawansowana
    ///

    new SwimmingExercise
    {
        Id = 135,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 136,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 137,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 138,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 139,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Żaba",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },



    ////////////// delfin podstaowowy 



    new SwimmingExercise
    {
        Id = 140,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 141,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 142,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 143,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 144,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Początkujący",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },

    ////////////// delfin zaawansowany
    ///

    new SwimmingExercise
    {
        Id = 145,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Nogi",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 146,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Ręce",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 147,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Wytrzymałość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 148,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Koordynacja",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    },
    new SwimmingExercise
    {
        Id = 149,
        IsDefault = true,
        Name = "Dowolna kombinacja",
        Distance = 300,
        Category = "Szybkość",
        Style = "Delfin",
        Level = "Zaawansowany",
        Description = "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała."
    }

    );

    }
  }
}
