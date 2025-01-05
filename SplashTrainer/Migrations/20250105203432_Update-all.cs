using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SplashTrainer.Migrations
{
    /// <inheritdoc />
    public partial class Updateall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwimmingExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingExercises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SwimmingPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalDistance = table.Column<int>(type: "INTEGER", nullable: false),
                    Goal = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false),
                    Style = table.Column<string>(type: "TEXT", nullable: false),
                    TrainingDays = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SwimmingPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SwimmingPlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Action = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_SwimmingPlans_SwimmingPlanId",
                        column: x => x.SwimmingPlanId,
                        principalTable: "SwimmingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlanExercises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SwimmingPlanId = table.Column<int>(type: "INTEGER", nullable: false),
                    SwimmingExerciseId = table.Column<int>(type: "INTEGER", nullable: false),
                    ExerciseDate = table.Column<string>(type: "TEXT", nullable: false),
                    ExerciseTime = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    Distance = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanExercises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanExercises_SwimmingExercises_SwimmingExerciseId",
                        column: x => x.SwimmingExerciseId,
                        principalTable: "SwimmingExercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlanExercises_SwimmingPlans_SwimmingPlanId",
                        column: x => x.SwimmingPlanId,
                        principalTable: "SwimmingPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SwimmingExercises",
                columns: new[] { "Id", "Category", "Description", "Distance", "IsDefault", "Level", "Name", "Style" },
                values: new object[,]
                {
                    { 10, "Nogi", "Deskę trzymaj na wyskości ud, na prostych rękach. Skup się na stabilnym tempie i równm ułożeniu bioder.", 50, true, "Początkujący", "Praca nóg z deską", "Grzbiet" },
                    { 11, "Nogi", "Utrzymuj równą pracę nóg na całym dystansie.", 100, true, "Początkujący", "Naprzemienne kopnięcia bez deski", "Grzbiet" },
                    { 12, "Nogi", "Pamiętaj o minimalnie ugiętych kolanach i o tym żeby nie wychodziły nad taflę wody oraz o poprawnie ułożonych biodrach.", 100, true, "Zaawansowany", "Wysokie kopnięcia nóg", "Grzbiet" },
                    { 13, "Nogi", "Złącz ręce za głową w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby kolana nie wychodziły nad wodę.", 100, true, "Zaawansowany", "Kopnięcia nóg z rękoma w strzałce", "Grzbiet" },
                    { 14, "Nogi", "Skup się na izolowaniu jednej nogi przed 25m.", 50, true, "Początkujący", "Praca jedną nogą", "Grzbiet" },
                    { 15, "Ręce", "Skup się na technice naprzemiennej pracy ramion.", 50, true, "Początkujący", "Praca rąk z pullboyem", "Grzbiet" },
                    { 16, "Ręce", "Utrzymuj symetryczną pracę rąk oraz stabilny korpus. Pamiętaj aby dłoń wkładać do wody zaczynając od małego palca, a wyciągać z wody zaczynając od kciuka.", 100, true, "Początkujący", "Naprzemienne praca rąk", "Grzbiet" },
                    { 17, "Ręce", "Zacznij od ruchu jedną ręką - drugą trzymaj wzdłuż ciała. Po wykonaniu ruchu, klaśnij delikatnie nad wodą, nad nogami. Trzymaj wyprostowane ręce. Następnie powtórz po ruchu drugiej ręki.", 100, true, "Zaawansowany", "Naprzemiennie z klaśnięciem", "Grzbiet" },
                    { 18, "Ręce", "Koncentruj się na delikatnym i precyzyjnym wejściu dłoni do wody - od małego palca. Wyjście zaczyna się od kciuka. Pamiętaj, aby nie uginać łokci.", 50, true, "Zaawansowany", "Ćwiczenie na precyzję wejścia rąk", "Grzbiet" },
                    { 19, "Ręce", "Pracuj jedną ręką prze 50m, utrzymując stabilną pozycję ciała.", 100, true, "Zaawansowany", "Praca jedną ręką", "Grzbiet" },
                    { 20, "Koordynacja", "Pamiętaj o synchronizacji pracy rąk i nóg.", 100, true, "Początkujący", "Równoczesna praca rąk i nóg", "Grzbiet" },
                    { 21, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wzdłuż bioder.Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Początkujący", "Dokładanka z rękoma wzdłuż ciała", "Grzbiet" },
                    { 22, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je przy biodrach na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Początkujący", "Dokładanka z rękoma wzdłuż ciała + zatrzymanie", "Grzbiet" },
                    { 23, "Koordynacja", "Umieść jedą rękę prostą za głową, a drugą wzdłuż ciała. Wykonuj ruchy naprzemiennie. Po każdym ruchu zatrzymanie rąk na 4 sekundy. Zachowaj pełną kontrolę nad pracą nóg i rąk.", 150, true, "Zaawansowany", "Zegar", "Grzbiet" },
                    { 24, "Koordynacja", "Utrzymuj biodra wysoko i spęty brzuch, podczas przekładania obu rąk. Dostosuj tempo do wydłużonych ruchów rąk.", 150, true, "Zaawansowany", "Praca obu rąk na raz", "Grzbiet" },
                    { 25, "Wytrzymałość", "Skup się na równomiernym oddechu i rytmie.", 200, true, "Początkujący", "Pływanie w równym tempie", "Grzbiet" },
                    { 26, "Wytrzymałość", "Płyń na 75% możliwości przez 100m, odpoczywaj przez 20 sekund.", 150, true, "Zaawansowany", "Wytrzymałość na długim dystansie", "Grzbiet" },
                    { 27, "Wytrzymałość", "Wdychaj co trzeci cykl, utrzymując stabilne tempo.", 100, true, "Początkujący", "Serie z kontrolą oddechu", "Grzbiet" },
                    { 28, "Wytrzymałość", "Zmieniaj tempo co 25m, przechodząc z szybkiego na wolne.", 150, true, "Zaawansowany", "Naprzemienne tempo", "Grzbiet" },
                    { 29, "Wytrzymałość", "Płyń w stałym tempie, kontrolując oddech i pracę ciała.", 250, true, "Zaawansowany", "Wydłużone dystanse w równym rytmie", "Grzbiet" },
                    { 30, "Szybkość", "Daj z siebie wszystko na krótkim odcinku.", 50, true, "Początkujący", "Sprint na krótkim dystansie", "Grzbiet" },
                    { 31, "Szybkość", "Zmieniaj intensywność co 25m. Zacznij od średniego tempa.", 75, true, "Zaawansowany", "Naprzemienne sprinty", "Grzbiet" },
                    { 32, "Szybkość", "Ćwicz szybki start i dynamiczne nawroty.", 100, true, "Zaawansowany", "Starty z nawrotem", "Grzbiet" },
                    { 33, "Szybkość", "Maksymalna intensywność na każdym 25m.", 25, true, "Początkujący", "Skrócone serie sprintów", "Grzbiet" },
                    { 34, "Szybkość", "Utrzymuj najwyższą intensywność przez cały dystans.", 100, true, "Zaawansowany", "Długie sprinty", "Grzbiet" },
                    { 35, "Nogi", "Utrzymuj biodra na powierzchni wody, staraj się trzymać je na jednym poziomie.", 50, true, "Początkujący", "Naprzemienne kopnięcia z deską", "Kraul" },
                    { 36, "Nogi", "Utrzymuj równą pracę nóg na całym dystansie.", 100, true, "Początkujący", "Naprzemienne kopnięcia bez deski", "Kraul" },
                    { 37, "Nogi", "Wykonuj energiczne i szybkie kopnięcia. Pamiętaj o minimalnie ugiętych kolanach i o poprawnie ułożonych biodrach.", 100, true, "Zaawansowany", "Wysokie kopnięcia nóg", "Kraul" },
                    { 38, "Nogi", "Złącz ręce za głową w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby stopy nie wychodziły nad wodę.", 150, true, "Zaawansowany", "Kopnięcia nóg z rękoma w strzałce", "Kraul" },
                    { 39, "Nogi", "Skup się na izolowaniu jednej nogi przed 25m.", 150, true, "Zaawansowany", "Praca jedną nogą", "Kraul" },
                    { 40, "Ręce", "Trzymaj biodra stabilnie i skup się na wiosłowaniu.", 50, true, "Początkujący", "Praca rąk z pullboyem", "Kraul" },
                    { 41, "Ręce", "Wykonuj ruch jedną ręką. Drugą trzymaj deskę. Utrzymuj stabilny korpus.", 100, true, "Początkujący", "Naprzemienne praca rąk z deską", "Kraul" },
                    { 42, "Ręce", "Skup się na pracy jedną ręką przez 50m. Możesz użyć deski.", 100, true, "Początkujący", "Praca jedną ręką", "Kraul" },
                    { 43, "Ręce", "Zwróć uwagę na synchronizację ruchów z regularnym oddechem.", 150, true, "Zaawansowany", "Synchronizacja rąk z oddechem", "Kraul" },
                    { 44, "Ręce", "Sięgaj ręką jak najdalej, odkręcaj bark. Koncentruj się na pełnym zakresie ruchu i efektywności pracy rąk.", 150, true, "Zaawansowany", "Wydłużenie cykli pracy rąk", "Kraul" },
                    { 45, "Koordynacja", "Dostosuj tempo nóg do ruchów rąk.", 100, true, "Początkujący", "Synchronizacja rąk i nóg", "Kraul" },
                    { 46, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wyprostowana z przodu obok drugiej ręki.Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Początkujący", "Dokładanka z rękoma wyprostowanymi z przodu", "Kraul" },
                    { 47, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je z przodu na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl.", 50, true, "Zaawansowany", "Dokładanka z rękoma wyprostowanymi z przodu + zatrzymanie", "Kraul" },
                    { 48, "Koordynacja", "Umieść jedą rękę prostą za głową, a drugą wzdłuż ciała. Wykonuj ruchy naprzemiennie. Po każdym ruchu zatrzymanie rąk na 4 sekundy. Zachowaj pełną kontrolę nad pracą nóg i rąk.", 150, true, "Zaawansowany", "Zegar", "Kraul" },
                    { 49, "Koordynacja", "Umieść jedą rękę prostą za głową, a drugą wzdłuż ciała. Wykonuj ruchy naprzemiennie. Po każdym ruchu, klepnij ręką w wodę. Zachowaj pełną kontrolę nad pracą nóg i rąk.", 150, true, "Zaawansowany", "Zegar + klepnięcie", "Kraul" },
                    { 50, "Wytrzymałość", "Skup się na utrzymaniu równomiernego oddechu.", 200, true, "Początkujący", "Pływanie w równym tempie", "Kraul" },
                    { 51, "Wytrzymałość", "Odpoczywaj 15 sekund po każdym dystansie 50m.", 150, true, "Zaawansowany", "Wytrzymałość z krótkimi przerwami", "Kraul" },
                    { 52, "Wytrzymałość", "Wdychaj co trzeci ruch ramion.", 100, true, "Początkujący", "Serie z kontrolą oddechu", "Kraul" },
                    { 53, "Wytrzymałość", "Przechodź między szybkim a wolnym tempem.", 150, true, "Zaawansowany", "Naprzemienne tempo co 25m", "Kraul" },
                    { 54, "Wytrzymałość", "Utrzymuj spokojny oddech i równomierne tempo.", 250, true, "Zaawansowany", "Długie dystanse w równym rytmie", "Kraul" },
                    { 55, "Szybkość", "Odpoczywaj 30 sekund między każdym sprintem.", 50, true, "Początkujący", "Sprinty na krótkim dystansie", "Kraul" },
                    { 56, "Szybkość", "Zmieniaj intensywność co 25m.", 75, true, "Zaawansowany", "Naprzemienne sprinty i pływanie luźne", "Kraul" },
                    { 57, "Szybkość", "Trenuj dynamiczne starty i nawroty z maksymalną intensywnością.", 100, true, "Zaawansowany", "Dynamiczne starty z nawrotem", "Kraul" },
                    { 58, "Szybkość", "Utrzymuj najwyższą intensywność na całym dystansie.", 50, true, "Zaawansowany", "Sprint", "Kraul" },
                    { 59, "Szybkość", "Staraj się utrzymać maksymalne tempo przez cały dystans.", 100, true, "Zaawansowany", "Maksymalna prędkość na dłuższym dystansie", "Kraul" },
                    { 60, "Nogi", "Skup się na szerokim ruchu nóg, przypominającym żabę. Pamiętaj aby kolana nie były za daleko od siebie.", 50, true, "Początkujący", "Naprzemienne kopnięcia z deską", "Żaba" },
                    { 61, "Nogi", "Po każdym ruchu, trzymaj złączone nogi, dopkóki nie stracisz całej prędkości. Pamiętaj o dokładnym prostowaniu nóg po każdym ruchu.", 100, true, "Początkujący", "Naprzemienne kopnięcia nóg + wyleżenie", "Żaba" },
                    { 62, "Nogi", "Wykonuj naprzemiennie mały okrąg nogami, a następnie pełen cykl - duży okrąg.", 100, true, "Zaawansowany", "Małe i duże kółeczka", "Żaba" },
                    { 63, "Nogi", "Złącz ręce za głową w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby stopy nie wychodziły nad wodę.", 150, true, "Zaawansowany", "Kopnięcia nóg z rękoma w strzałce", "Żaba" },
                    { 64, "Nogi", "Skup się na izolowaniu jednej nogi przed 25m.", 150, true, "Zaawansowany", "Praca jedną nogą", "Żaba" },
                    { 65, "Ręce", "Trzymaj nogi stabilnie i skup się na ruchu rąk.", 50, true, "Początkujący", "Ruchy rąk z pullboyem", "Żaba" },
                    { 66, "Ręce", "Skup się na pełnym zakresie ruchu jednej ręki.", 100, true, "Początkujący", "Praca jedną ręką na zmianę", "Żaba" },
                    { 67, "Ręce", "Dostosuj rytm rąk do odpowiedniego momentu oddechu.", 100, true, "Zaawansowany", "Synchronizacja rąk z oddechem", "Żaba" },
                    { 68, "Ręce", "Skup się na pracy rąk. Wykomując nogi do kraula, łatwiej skupisz się na technice pracy rąk do żaby.", 150, true, "Zaawansowany", "Żabo-Kraul", "Żaba" },
                    { 69, "Ręce", "Skup się na spokojnym i pełnym zakresie ruchu.", 150, true, "Zaawansowany", "Wydłużone cykle pracy rąk", "Żaba" },
                    { 70, "Koordynacja", "Dostosuj rytm nóg do ruchu rąk.", 100, true, "Początkujący", "Synchronizacja nóg i rąk", "Żaba" },
                    { 71, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wyprostowana z przodu obok drugiej ręki.Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Początkujący", "Dokładanka z rękoma wyprostowanymi z przodu", "Żaba" },
                    { 72, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je z przodu na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Zaawansowany", "Dokładanka z rękoma wyprostowanymi z przodu + zatrzymanie", "Żaba" },
                    { 73, "Koordynacja", "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowe mocne kopnięcie nogami.", 150, true, "Zaawansowany", "Pełen cykl + dodatkowe kopnięcie", "Żaba" },
                    { 74, "Koordynacja", "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowy ruch rękoma.", 150, true, "Zaawansowany", "Pełen cykl + dodatkowy ruch rękoma", "Żaba" },
                    { 75, "Wytrzymałość", "Skup się na utrzymaniu stałego tempa przez cały dystans.", 200, true, "Początkujący", "Równomierne tempo na dystansie", "Żaba" },
                    { 76, "Wytrzymałość", "Płyń 50m, odpoczywaj 15 sekund.", 150, true, "Początkujący", "Wytrzymałość z krótkimi przerwami", "Żaba" },
                    { 77, "Wytrzymałość", "Utrzymuj kontrolę nad oddechem i tempem.", 300, true, "Zaawansowany", "Długie dystanse w równym rytmie", "Żaba" },
                    { 78, "Wytrzymałość", "Spróbuj przepłynąć żabą 25m pod wodą.", 25, true, "Zaawansowany", "Żabo-Nurek", "Żaba" },
                    { 79, "Wytrzymałość", "Zmieniaj tempo co 50m, przechodząc z wolnego na szybkie.", 250, true, "Zaawansowany", "Naprzemienne tempo co 50", "Żaba" },
                    { 80, "Szybkość", "Daj z siebie wszystko przez 50m, odpoczywaj 30 sekund.", 50, true, "Początkujący", "Sprinty z przerwami", "Żaba" },
                    { 81, "Szybkość", "Ćwicz szybkie starty i nawroty na krótkim dystansie.", 100, true, "Zaawansowany", "Dynamiczne starty z nawrotem", "Żaba" },
                    { 82, "Szybkość", "Zmieniaj intensywność co 25m. Szybko / luźno.", 75, true, "Zaawansowany", "Naprzemienne tempo sprintów", "Żaba" },
                    { 83, "Szybkość", "Płyń maksymalnym tempem przez każdy dystans.", 50, true, "Zaawansowany", "Sprint", "Żaba" },
                    { 84, "Szybkość", "Staraj się utrzymać maksymalne tempo przez cały dystans.", 100, true, "Zaawansowany", "Wydłużone sprinty", "Żaba" },
                    { 85, "Nogi", "Nogi muszą pracować jednocześnie. Skup się na rytmicznej pracy bioder i nóg.", 50, true, "Początkujący", "Praca nóg z deską", "Delfin" },
                    { 86, "Nogi", "Połóż się na wyciągniętej ręce z przodu. Drugą trzymaj wzdłuż ciała. Utrzymuj biodra na powierzchni wody.", 100, true, "Początkujący", "Kopnięcia nóg na boku", "Delfin" },
                    { 87, "Nogi", "Trzymaj ręce złączone w strzałce. Zrób krótką przerwę każdych 25m. Staraj się przepłynąć pod wodą jak najdłużej.", 100, true, "Zaawansowany", "Pod wodą + strzałka", "Delfin" },
                    { 88, "Nogi", "Trzymaj ręce wzdłuż ciała. Co 3 kopnięcia nabieraj oddech, bez odrywania rąk.", 150, true, "Zaawansowany", "Praca nóg + oddech", "Delfin" },
                    { 89, "Nogi", "Złącz ręce przed sobą w strzałce. Trzymaj brzuch napięty oraz pilnuj, aby stopy nie wychodziły nad wodę.", 150, true, "Zaawansowany", "Naprzemienne kopnięcia z deski", "Delfin" },
                    { 90, "Ręce", "Ułóż ręce proste przed sobą. Delikatnie ugnij nadgarstki i pociągnij prostymi rękoma, aż do lini bioder. Zatrzymaj tam ręce wyprostowane i poczekaj, aż stracisz prędkość. ", 100, true, "Początkujący", "Pół - odepchnięcia pod wodą", "Delfin" },
                    { 91, "Ręce", "Trzymaj nogi stabilnie i skup się na ruchu rąk.", 50, true, "Początkujący", "Praca rąk z pullboyem", "Delfin" },
                    { 92, "Ręce", "Pamiętaj, aby nie uginać ręki pod wodą. Nad wodą przenoś rękę bokiem. Skup się na pełnym zakresie ruchu jednej ręki. Zmieniaj rękę co 25m.", 100, true, "Zaawansowany", "Praca jedną ręką na zmianę", "Delfin" },
                    { 93, "Ręce", "Skup się na pracy rąk. Wykomując nogi do kraula, łatwiej skupisz się na technice pracy rąk do delfina.", 150, true, "Zaawansowany", "Kraulo-Delfin", "Delfin" },
                    { 94, "Ręce", "Wykonuj dokładankę płynąć jeden ruch jedną ręką, na zmianę z drugą.", 150, true, "Zaawansowany", "Dokładanka 1/2", "Delfin" },
                    { 95, "Koordynacja", "Połącz równomierne ruchy nóg i rąk.", 50, true, "Początkujący", "Synchronizacja nóg i rąk", "Delfin" },
                    { 96, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Zaczynaj parcę drugą ręką dopiero, gdy pierwsza znajdzie się wyprostowana z przodu obok drugiej ręki.Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Początkujący", "Dokładanka z rękoma wyprostowanymi z przodu", "Delfin" },
                    { 97, "Koordynacja", "Wykonuj naprzemiennie ruch rękoma. Po każdym ruchu ręką, zatrzymaj je z przodu na 4 sekundy. Utrzymuj równomierny rytm przez cały cykl.", 100, true, "Zaawansowany", "Dokładanka z rękoma wyprostowanymi z przodu + zatrzymanie", "Delfin" },
                    { 98, "Koordynacja", "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowe mocne kopnięcie nogami.", 100, true, "Zaawansowany", "Pełen cykl + dodatkowe kopnięcie", "Delfin" },
                    { 99, "Koordynacja", "Po każdym cyklu (kopnięcie nogami i ruch rękoma), wykonaj dodatkowy ruch rękoma.", 150, true, "Zaawansowany", "Pełen cykl + dodatkowy ruch rękoma", "Delfin" },
                    { 100, "Wytrzymałość", "Skup się na utrzymaniu stałego rytmu i oddechu.", 100, true, "Początkujący", "Pływanie w równym tempie", "Delfin" },
                    { 101, "Wytrzymałość", "Przepłyń 50, odpoczywaj 15 sekund, powtarzaj.", 150, true, "Początkujący", "Tlenowe z krótkimi przerwami", "Delfin" },
                    { 102, "Wytrzymałość", "Utrzymuj równy rytm na długim dystansie.", 150, true, "Zaawansowany", "Długi dystans w stałym tempie", "Delfin" },
                    { 103, "Wytrzymałość", "Skup się na równomiernym oddechu co trzeci ruch ramion.", 100, true, "Zaawansowany", "Seria z kontrolą oddechu", "Delfin" },
                    { 104, "Wytrzymałość", "Zmieniając tempo co 50m ( szybko/ wolno). ćwicz kontrolę nad wysiłkiem.", 250, true, "Zaawansowany", "Zmienność tempa na dystansie", "Delfin" },
                    { 105, "Szybkość", "Daj z siebie wszystko na krótkich dystansach.", 25, true, "Początkujący", "Sprinty 25m", "Delfin" },
                    { 106, "Szybkość", "Zmieniaj intensywność co 25m, przechodząc od sprintu do luźnego tempa.", 75, true, "Zaawansowany", "Naprzemienne sprinty i luźne tempo", "Delfin" },
                    { 107, "Szybkość", "Ćwicz szybkie starty i dynamiczne nawroty.", 50, true, "Zaawansowany", "Dynamiczne starty z nawrotem", "Delfin" },
                    { 108, "Szybkość", "Utrzymuj maksymalną intensywność przez 50m.", 50, true, "Zaawansowany", "Sprint 50m", "Delfin" },
                    { 109, "Szybkość", "Staraj się utrzymać maksymalne tempo przez cały dystans.", 100, true, "Zaawansowany", "Sprint na dłuższym dystansie", "Delfin" },
                    { 110, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Grzbiet" },
                    { 111, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Grzbiet" },
                    { 112, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Grzbiet" },
                    { 113, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Grzbiet" },
                    { 114, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Grzbiet" },
                    { 115, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Grzbiet" },
                    { 116, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Grzbiet" },
                    { 117, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Grzbiet" },
                    { 118, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Grzbiet" },
                    { 119, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Grzbiet" },
                    { 120, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Kraul" },
                    { 121, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Kraul" },
                    { 122, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Kraul" },
                    { 123, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Kraul" },
                    { 124, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Kraul" },
                    { 125, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Kraul" },
                    { 126, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Kraul" },
                    { 127, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Kraul" },
                    { 128, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Kraul" },
                    { 129, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Kraul" },
                    { 130, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Żaba" },
                    { 131, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Żaba" },
                    { 132, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Żaba" },
                    { 133, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Żaba" },
                    { 134, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Żaba" },
                    { 135, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Żaba" },
                    { 136, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Żaba" },
                    { 137, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Żaba" },
                    { 138, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Żaba" },
                    { 139, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Żaba" },
                    { 140, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Delfin" },
                    { 141, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Delfin" },
                    { 142, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Delfin" },
                    { 143, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Delfin" },
                    { 144, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Początkujący", "Dowolna kombinacja", "Delfin" },
                    { 145, "Nogi", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Delfin" },
                    { 146, "Ręce", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Delfin" },
                    { 147, "Wytrzymałość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Delfin" },
                    { 148, "Koordynacja", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Delfin" },
                    { 149, "Szybkość", "Miksuj swoje ulubione ćwiczenia, pamiętając o technice i poprawnym ułożeniu ciała.", 300, true, "Zaawansowany", "Dowolna kombinacja", "Delfin" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_SwimmingPlanId",
                table: "ActivityLogs",
                column: "SwimmingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlanExercises_SwimmingExerciseId",
                table: "PlanExercises",
                column: "SwimmingExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanExercises_SwimmingPlanId",
                table: "PlanExercises",
                column: "SwimmingPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "PlanExercises");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SwimmingExercises");

            migrationBuilder.DropTable(
                name: "SwimmingPlans");
        }
    }
}
