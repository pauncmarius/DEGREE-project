using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FCUnirea.Persistance.Data.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "News",
                type: "NVARCHAR(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "NVARCHAR(MAX)",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserId", "CreatedAt", "Text" },
                values: new object[] { 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4109), "Felicitări echipei! Suntem mândri că FC Unirea ajunge și în Champions League!" });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 2, 1, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4113), "Forza Unirea! Abia aștept meciurile din toate cele trei competiții!" },
                    { 3, 1, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4114), "Va fi un sezon greu, dar cu susținerea noastră sigur veți reuși!" },
                    { 4, 1, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4115), "Mult succes băieților, mai ales în Champions League! Suntem alături de voi!" },
                    { 5, 1, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4116), "Bravo! Să dovediți că sunteți cei mai buni atât în țară, cât și în Europa!" },
                    { 6, 1, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4117), "Aștept cu nerăbdare derby-urile din Liga 1! Haideți să câștigăm tot!" },
                    { 7, 1, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4119), "Băieți, să jucați cu inima și să nu vă lăsați niciodată!" },
                    { 8, 1, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4120), "Să avem un sezon plin de victorii! Mult succes și în Cupa României!" },
                    { 9, 1, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4121), "Ne vedem pe stadion! Vom fi mereu în spatele vostru, orice ar fi!" },
                    { 10, 1, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4122), "Felicitări întregului staff! Muncă, pasiune și dedicare – doar așa vom ajunge departe!" },
                    { 11, 2, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4133), "Mult succes băieților din U21! Abia aștept să văd tineri noi pe teren." },
                    { 12, 2, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4134), "Bravo, Unirea! E important să investiți în tineret." },
                    { 13, 2, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4135), "Forță, U21! Aveți toată susținerea noastră, haideți să arătați ce puteți!" },
                    { 14, 2, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4136), "Felicitări staff-ului pentru încrederea oferită tinerilor!" },
                    { 15, 2, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4137), "Este o șansă mare pentru voi. Luptați până la capăt!" },
                    { 16, 2, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4139), "Hai, Unirea U21! Viitorul începe cu voi!" },
                    { 17, 2, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4140), "Sper să vedem cât mai mulți dintre voi în echipa mare!" },
                    { 18, 2, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4141), "Este important să creștem talente locale. Mult succes!" },
                    { 19, 2, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4142), "Fiecare meci e o experiență nouă. Dați totul pe teren!" },
                    { 20, 2, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4144), "Vă țin pumnii la fiecare etapă! Hai, băieții!" },
                    { 21, 3, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4154), "Felicitări micilor Uniriști! Sunteți viitorul clubului!" },
                    { 22, 3, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4155), "Este minunat să vedem atât de mulți copii talentați la Unirea!" },
                    { 23, 3, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4157), "Mult succes în noul sezon! Să creșteți frumos și cu ambiție!" },
                    { 24, 3, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4158), "Bravo, FC Unirea Youth! Sunt sigur că veți impresiona!" },
                    { 25, 3, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4159), "Susținerea suporterilor e mereu cu voi, indiferent de vârstă!" },
                    { 26, 3, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4160), "Aștept să văd următoarea generație pe terenul mare!" },
                    { 27, 3, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4161), "Este foarte important să investiți în copii! Multă baftă!" },
                    { 28, 3, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4162), "Bucuria și pasiunea voastră pentru fotbal ne inspiră pe toți!" },
                    { 29, 3, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4163), "Să aveți parte de un sezon plin de goluri și zâmbete!" },
                    { 30, 3, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4165), "Felicitări și succes! Sper să vă vedem în curând la echipa mare!" },
                    { 31, 4, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4173), "Respect pentru întreaga istorie a clubului! Hai Unirea!" },
                    { 32, 4, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4213), "Felicitări pentru toate promovările și pentru ce ați construit!" },
                    { 33, 4, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4214), "Antrenorul Petrica Florea a făcut o treabă excelentă. Mult succes în continuare!" },
                    { 34, 4, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4215), "FC Unirea este un exemplu pentru fotbalul românesc!" },
                    { 35, 4, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4216), "Mă bucur că investește în tineri și promovează valorile locale." },
                    { 36, 4, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4218), "Succes pe mai departe, Petrica Florea și întreaga echipă!" },
                    { 37, 4, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4219), "Felicitări pentru tot ce ați realizat de la înființare până azi!" },
                    { 38, 4, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4220), "Echipa asta chiar merită să fie susținută, se vede progresul an de an." },
                    { 39, 4, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4221), "Hai Unirea! Să continuați să ne faceți mândri!" },
                    { 40, 4, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4223), "Toată stima pentru staff și pentru antrenorul nostru! Înainte, Unirea!" },
                    { 41, 5, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4232), "Felicitări pentru tot ce faceți pentru tinerii jucători!" },
                    { 42, 5, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4233), "Strategia clubului dă rezultate. Mulți dintre favoriții mei au venit de aici!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 43, 5, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4235), "Bravo, Mihai Olaru! Se vede implicarea și profesionalismul echipei." },
                    { 44, 5, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4236), "Îmi place că se pune accent pe disciplină și joc de echipă." },
                    { 45, 5, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4237), "Este foarte importantă această legătură între juniori și seniori!" },
                    { 46, 5, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4238), "Succes în noul sezon! Sunt sigur că veți promova noi talente." },
                    { 47, 5, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4239), "FC Unirea U21 a devenit o adevărată pepinieră de jucători." },
                    { 48, 5, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4240), "Felicitări întregului staff pentru munca depusă!" },
                    { 49, 5, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4241), "Am încredere că veți duce mai departe tradiția clubului!" },
                    { 50, 5, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4243), "Hai Unirea U21, să aveți un sezon excelent!" },
                    { 51, 6, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4252), "Felicitări pentru investiția în copii și pentru tot ce faceți la nivel de academie!" },
                    { 52, 6, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4253), "Este minunat să vedem o academie care chiar scoate talente!" },
                    { 53, 6, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4254), "Respect pentru Nica Cercel și pentru toți antrenorii de la Youth." },
                    { 54, 6, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4255), "Unirea Youth este un exemplu pentru multe cluburi din țară." },
                    { 55, 6, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4256), "Mă bucur să văd accent pe educație și respect, nu doar pe performanță." },
                    { 56, 6, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4258), "Hai Unirea Youth! Să creșteți mari și să ajungeți cât mai sus!" },
                    { 57, 6, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4259), "Bravo tuturor pentru rezultatele obținute la nivel de juniori!" },
                    { 58, 6, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4260), "Sprijinul pentru copii și adolescenți face diferența pe termen lung." },
                    { 59, 6, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4261), "Am încredere că Unirea Youth va produce generații de campioni." },
                    { 60, 6, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4263), "Felicitări Nica Cercel pentru munca extraordinară din academie!" },
                    { 61, 7, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4270), "Lot foarte echilibrat, avem șanse mari la titlu anul acesta!" },
                    { 62, 7, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4272), "Mă bucur să văd și mulți tineri promovați în echipă!" },
                    { 63, 7, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4273), "Forza Unirea! Fundașii noștri sunt printre cei mai buni din campionat." },
                    { 64, 7, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4274), "Portarii au experiență și pot aduce multe puncte!" },
                    { 65, 7, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4275), "Felicitări staff-ului pentru selecție! Arată foarte bine lotul." },
                    { 66, 7, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4276), "Sper să vedem cât mai multe goluri de la atacanți!" },
                    { 67, 7, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4277), "Mult succes echipei în noul sezon, vom fi mereu în tribune!" },
                    { 68, 7, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4278), "Îmi place echilibrul între experiență și tinerețe." },
                    { 69, 7, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4279), "Haideți băieți, să facem un sezon de neuitat!" },
                    { 70, 7, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4281), "Bravo Unirea, arătați ca o echipă pregătită pentru orice!" },
                    { 71, 8, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4290), "Lot promițător! Avem mulți tineri cu potențial în acest sezon." },
                    { 72, 8, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4291), "Portarii sunt foarte tineri, abia aștept să-i văd la lucru!" },
                    { 73, 8, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4292), "Fundașii noștri par foarte bine pregătiți. Hai, Unirea U21!" },
                    { 74, 8, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4293), "Felicitări staff-ului pentru alegerea lotului, multă baftă!" },
                    { 75, 8, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4294), "Mijlocul arată echilibrat, cu jucători din generații diferite." },
                    { 76, 8, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4296), "Atacanții noștri sunt talentați, sper să înscrie cât mai mult!" },
                    { 77, 8, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4297), "Se vede accentul pus pe formarea tinerilor, bravo clubului!" },
                    { 78, 8, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4298), "Să avem un sezon plin de reușite și fără accidentări!" },
                    { 79, 8, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4299), "Hai Unirea U21, susținem viitorul echipei mari!" },
                    { 80, 8, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4300), "Mult succes tuturor băieților! Haideți să arătăm ce putem!" },
                    { 81, 9, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4308), "Felicitări tuturor copiilor și antrenorilor, să aveți un sezon minunat!" },
                    { 82, 9, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4310), "Lot numeros și diversificat, viitorul sună bine la Unirea!" },
                    { 83, 9, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4311), "Succes portărilor noștri cei mici! Să apere cu curaj poarta Unirii!" },
                    { 84, 9, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4312), "Mijlocașii sunt motorul echipei! Bravo, băieți!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 85, 9, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4313), "Felicitări tuturor atacanților, să aveți un sezon plin de goluri!" },
                    { 86, 9, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4314), "Echipa Youth arată foarte bine, multă baftă pe teren!" },
                    { 87, 9, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4354), "Bravo clubului pentru investiția constantă în copii!" },
                    { 88, 9, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4356), "Sper ca mulți dintre acești jucători să ajungă la seniori!" },
                    { 89, 9, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4357), "Un sezon plin de reușite vă doresc, haideți să ne faceți mândri!" },
                    { 90, 9, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4359), "Hai Unirea Youth, sunteți viitorul echipei mari!" },
                    { 91, 10, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4368), "Se vede câtă muncă se depune la nivel de copii, felicitări clubului!" },
                    { 92, 10, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4369), "Mult succes portărilor noștri, să aveți un sezon de excepție!" },
                    { 93, 10, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4370), "Fundașii sunt foarte bine reprezentanți, bravo băieți!" },
                    { 94, 10, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4371), "Mijlocul echipei Youth arată foarte bine, multă energie și determinare!" },
                    { 95, 10, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4372), "Atacanții noștri vor marca sigur multe goluri!" },
                    { 96, 10, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4374), "Felicitări antrenorilor pentru selecție și muncă!" },
                    { 97, 10, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4375), "Hai Unirea Youth, să fiți uniți și să vă bucurați de fotbal!" },
                    { 98, 10, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4376), "Clubul are cu adevărat grijă de viitorul fotbalului local!" },
                    { 99, 10, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4377), "Sper să vedem cât mai mulți dintre voi la echipa mare în curând!" },
                    { 100, 10, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4379), "Mult succes tuturor copiilor și un sezon fără accidentări!" },
                    { 101, 11, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4388), "Un stadion mic, dar cu o atmosferă extraordinară!" },
                    { 102, 11, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4389), "Odobestiul trăiește pentru fotbal! Hai Unirea!" },
                    { 103, 11, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4390), "Aici ne simțim cu adevărat acasă, aproape de echipă!" },
                    { 104, 11, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4391), "Fiecare meci pe acest stadion e special pentru noi." },
                    { 105, 11, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4392), "De-abia aștept să reînceapă sezonul și să fiu pe stadion!" },
                    { 106, 11, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4394), "Hai Unirea, să ne faceți mândri pe Unirea Stadium!" },
                    { 107, 11, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4395), "Sunt multe amintiri frumoase legate de acest stadion." },
                    { 108, 11, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4396), "Respect pentru toți suporterii care vin la fiecare meci!" },
                    { 109, 11, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4397), "Mic, dar esențial pentru spiritul echipei noastre!" },
                    { 110, 11, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4399), "Hai Unirea, pe Unirea Stadium scriem istorie!" },
                    { 111, 12, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4406), "Atmosfera la meciurile U21 e mereu specială!" },
                    { 112, 12, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4408), "Un stadion mic, dar perfect pentru meciurile tinerilor." },
                    { 113, 12, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4409), "Sunt mândru să văd juniorii noștri crescând pe acest teren." },
                    { 114, 12, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4410), "Fiecare meci e o lecție de fotbal pentru tinerii noștri." },
                    { 115, 12, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4411), "Felicitări clubului că investește în tineret!" },
                    { 116, 12, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4413), "Hai Unirea U21, să aveți un sezon plin de victorii!" },
                    { 117, 12, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4414), "Toți cei care vin la stadion sunt parte din familia Unirea!" },
                    { 118, 12, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4415), "Este important ca juniorii să aibă propriul lor stadion." },
                    { 119, 12, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4416), "Meciurile U21 sunt întotdeauna pline de energie!" },
                    { 120, 12, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4417), "Sunt sigur că Unirea U21 va avea un sezon de excepție pe acest stadion!" },
                    { 121, 13, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4425), "Felicitări pentru grija față de cei mici! Un stadion cu adevărat special." },
                    { 122, 13, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4427), "Unirea Youth Stadium e locul unde începe povestea fiecărui campion!" },
                    { 123, 13, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4428), "Fiecare copil merită să joace pe un teren atât de primitor." },
                    { 124, 13, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4429), "Aici se simte bucuria fotbalului autentic!" },
                    { 125, 13, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4430), "Bravo clubului că investește în condiții pentru copii!" },
                    { 126, 13, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4432), "Meciurile de la Youth Stadium sunt mereu pline de entuziasm." }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 127, 13, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4433), "Felicitări tinerilor jucători pentru determinare și curaj!" },
                    { 128, 13, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4434), "Hai Unirea Youth! Vă susținem la fiecare meci!" },
                    { 129, 13, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4435), "Important să avem astfel de baze pentru generațiile următoare." },
                    { 130, 13, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4436), "Succes tuturor copiilor care își trăiesc visul pe acest stadion!" },
                    { 131, 14, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4445), "VIP-ul e perfect pentru cei care vor să vadă meciul în cele mai bune condiții!" },
                    { 132, 14, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4447), "Prețurile sunt accesibile pentru toată lumea, bravo clubului!" },
                    { 133, 14, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4448), "Mereu aleg Standard, acolo atmosfera e cea mai tare!" },
                    { 134, 14, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4449), "Felicitări pentru organizare, abia aștept următorul meci acasă!" },
                    { 135, 14, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4450), "Îmi place diversitatea locurilor, fiecare își găsește ceva pe plac." },
                    { 136, 14, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4488), "Vreau să-mi iau bilet VIP la derby-ul cu rivala, e clar!" },
                    { 137, 14, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4491), "Hai Unirea, oriunde aș sta, important e să fim alături de voi!" },
                    { 138, 14, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4491), "Apreciez efortul clubului de a oferi condiții cât mai bune fanilor." },
                    { 139, 14, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4492), "Să fie stadionul plin la fiecare meci, doar așa câștigăm împreună!" },
                    { 140, 14, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4494), "Forza Unirea! Ne vedem la următorul meci pe Unirea Stadium!" }
                });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3977), "FC Unirea este încântată să anunțe participarea în trei competiții importante în sezonul acesta: Liga 1, Cupa României și Champions League.\n\nParticiparea în **Liga 1** aduce un nou prilej pentru echipa noastră de a lupta pentru titlul național, alături de cele mai bune echipe din țară.\n\nÎn **Cupa României**, obiectivul nostru este să mergem cât mai departe în competiție și să aducem suporterilor momente de neuitat.\n\nNu în ultimul rând, prezența în **Champions League** reprezintă un vis devenit realitate! Este o șansă uriașă pentru echipă de a se confrunta cu formații de top din Europa, de a acumula experiență și de a duce numele FC Unirea pe cele mai mari stadioane.\n\nVă invităm să fiți alături de noi în acest sezon de excepție! Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3981), "Echipa FC Unirea U21 va concura exclusiv în Liga 1 U21 în acest sezon, o competiție dedicată tinerilor talentați care fac parte din generația viitorului.\n\nLiga 1 U21 reprezintă o oportunitate excelentă pentru jucătorii noștri să-și demonstreze abilitățile și să facă pasul spre echipa mare. Antrenorii și staff-ul tehnic sunt încrezători că tinerii vor aduce rezultate bune și vor evolua de la meci la meci.\n\nObiectivul principal este dezvoltarea jucătorilor, promovarea valorilor clubului și pregătirea lor pentru a face față provocărilor fotbalului de performanță.\n\nSusțineți FC Unirea U21 în această nouă aventură fotbalistică! Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3982), "Avem bucuria să anunțăm că echipa FC Unirea Youth va evolua în acest sezon în **Liga 1 de tineret**!\n\nAceastă competiție este dedicată tinerilor fotbaliști cu potențial, care se pregătesc pentru pasul următor în cariera lor sportivă. Obiectivul clubului este să descopere noi talente și să le ofere oportunitatea de a juca la nivel înalt încă de la o vârstă fragedă.\n\nPrin participarea în Liga 1 de tineret, FC Unirea Youth urmărește nu doar rezultate, ci și dezvoltarea continuă a jucătorilor, spiritul de echipă și promovarea fair-play-ului.\n\nLe dorim mult succes tinerilor noștri și suntem convinși că vor reprezenta cu mândrie culorile clubului! Susțineți FC Unirea Youth la fiecare meci!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3983), "FC Unirea a fost fondată în anul 2005, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\n\nEchipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016.\n\nÎn prezent, echipa este pregătită de antrenorul Petrica Florea, sub îndrumarea căruia FC Unirea continuă să-și consolideze poziția în fotbalul românesc și să inspire o nouă generație de sportivi. Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3984), "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. Echipa a luat naștere în anul 2013, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\n\nÎncă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\n\nPrin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice.\n\nÎn prezent, echipa este pregătită de antrenorul Mihai Olaru, sub îndrumarea căruia tinerii își pot atinge potențialul și pot face pasul spre echipa de seniori. Hai, Unirea U21!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3986), "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. Echipa a fost creată în anul 2010 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\n\nScopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\n\nPrin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune.\n\nÎn prezent, echipa este antrenată de Nica Cercel, un tehnician recunoscut pentru devotamentul său față de copii și pentru rezultatele obținute la nivel juvenil. Hai, Unirea Youth!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3987), "Echipa FC Unirea pornește la drum în noul sezon cu un lot valoros, format din jucători experimentați și tineri de perspectivă. Iată componența lotului:\n\n**Portari:**  \n- Daniel Rădulescu (1992)  \n- Denis Chiriac (1997)  \n- Alin Neagu (2006)  \n- Ionuț Rădulescu (2004)  \n\n**Fundași:**  \n- Ștefan Popescu (1996)  \n- Radu Ilie (1999)  \n- Alex Lazăr (1995)  \n- Andrei Enache (1998)  \n- Andrei Neagu (2004)  \n- Robert Vasilescu (1996)  \n- Vlad Enache (1990)  \n\n**Mijlocași:**  \n- Mihai Toma (2000)  \n- Daniel Matei (1994)  \n- Sergiu Chiriac (1990)  \n- Denis Neagu (1999)  \n- George Ilie (2004)  \n- Gabriel Vasilescu (2005)  \n\n**Atacanți:**  \n- Daniel Stan (2003)  \n- Alex Vasilescu (1994)  \n- Denis Ilie (1991)  \n\nEchipa este pregătită să facă performanță și să aducă noi bucurii suporterilor!\n\nHai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3988), "FC Unirea U21 abordează noul sezon cu o echipă tânără, plină de entuziasm și determinare. Lotul reunește atât jucători cu experiență la nivel de juniori, cât și talente aflate la început de drum, dornice să confirme la cel mai înalt nivel al fotbalului de tineret. Iată componența lotului:\n\n**Portari:**  \n- Denis Lazar (2004)  \n- Eduard Georgescu (2006)  \n- Alin Dumitrescu (2008)  \n- Eduard Diaconu (2005)  \n- Robert Dumitrescu (2007)  \n\n**Fundași:**  \n- George Diaconu (2006)  \n- Adrian Toma (2007)  \n- Alin Diaconu (2004)  \n- Alin Voicu (2005)  \n- Sergiu Radulescu (2005)  \n\n**Mijlocași:**  \n- Daniel Ilie (2008)  \n- Alex Matei (2005)  \n- Robert Cojocaru (2008)  \n- Denis Cojocaru (2007)  \n\n**Atacanți:**  \n- Cristian Ilie (2005)  \n- Robert Ionescu (2004)  \n- Robert Radulescu (2007)  \n- Florin Matei (2005)  \n- Sergiu Neagu (2004)  \n- Eduard Popescu (2004)  \n\nPrin această selecție, FC Unirea U21 își propune să crească jucători valoroși, capabili să facă pasul spre fotbalul de seniori.\n\nMult succes în noul sezon, U21! Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3989), "FC Unirea Youth aliniază în acest sezon un lot numeros, format din copii și adolescenți talentați, cu dorință de afirmare și mult entuziasm. Mulți dintre acești jucători reprezintă viitorul clubului și al fotbalului local. Iată componența lotului:\n\n**Portari:**  \n- Cristian Matei (2011)  \n- Vlad Ilie (2012)  \n- Ionuț Neagu (2009)  \n- Adrian Cojocaru (2012)  \n- Paul Vasilescu (2011)  \n- Alin Neagu (2010)  \n- Cristian Chiriac (2010)  \n\n**Fundași:**  \n- Gabriel Ionescu (2011)  \n\n**Mijlocași:**  \n- Alin Vasilescu (2012)  \n- Andrei Ionescu (2009)  \n- Vlad Ionescu (2011)  \n- Sergiu Enache (2011)  \n- Alex Vasilescu (2010)  \n- Adrian Toma (2009)  \n- Vlad Neagu (2011)  \n- Ionuț Ilie (2010)  \n\n**Atacanți:**  \n- Paul Rădulescu (2011)  \n- Alin Ionescu (2009)  \n- George Neagu (2010)  \n- Ionuț Diaconu (2009)  \n\nClubul investește permanent în dezvoltarea acestor copii, asigurându-le pregătire modernă și condiții optime pentru a-și atinge potențialul. Mult succes, Unirea Youth!\n\nHai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3990), "FC Unirea Youth intră în noul sezon cu o echipă tânără și echilibrată, construită pe valori solide și pe dorința de afirmare a fiecărui copil. Jucătorii acestei generații sunt dovada investiției clubului în viitor, iar energia și ambiția lor se văd la fiecare antrenament și meci. Iată lotul complet:\n\n**Portari:**  \n- Adrian Cojocaru (2012)  \n- Alin Neagu (2010)  \n- Cristian Chiriac (2010)  \n\n**Fundași:**  \n- Cristian Matei (2011)  \n- Vlad Ilie (2012)  \n- Ionuț Neagu (2009)  \n- Gabriel Ionescu (2011)  \n- Paul Vasilescu (2011)  \n\n**Mijlocași:**  \n- Alin Vasilescu (2012)  \n- Andrei Ionescu (2009)  \n- Vlad Ionescu (2011)  \n- Sergiu Enache (2011)  \n- Alex Vasilescu (2010)  \n- Adrian Toma (2009)  \n- Vlad Neagu (2011)  \n- Ionuț Ilie (2010)  \n\n**Atacanți:**  \n- Paul Rădulescu (2011)  \n- Alin Ionescu (2009)  \n- George Neagu (2010)  \n- Ionuț Diaconu (2009)  \n\nLotul este rezultatul muncii academiei și reflectă preocuparea permanentă pentru dezvoltarea tinerelor talente.  \nSucces, Unirea Youth! Hai, copii!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3991), "FC Unirea își dispută meciurile de acasă pe **Unirea Stadium**, situat în orașul Odobești.\n\nStadionul dispune de o capacitate de 10 locuri și este destinat exclusiv meciurilor echipelor clubului, oferind o atmosferă caldă și apropiată de comunitatea locală. De-a lungul timpului, Unirea Stadium a găzduit numeroase momente speciale pentru suporterii alb-albaștrilor, devenind un simbol al pasiunii pentru fotbal în zonă.\n\nFiecare partidă jucată pe Unirea Stadium înseamnă emoție, determinare și susținere necondiționată din partea fanilor. Clubul mulțumește tuturor celor care vin să susțină echipa și promite să facă din fiecare meci o adevărată sărbătoare a fotbalului.\n\nHai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3992), "FC Unirea U21 joacă meciurile de acasă pe **Unirea U21 Stadium**, în orașul Odobești.\n\nStadionul oferă o capacitate de 10 locuri și a devenit un loc familiar pentru generațiile de tineri fotbaliști ai clubului. Fiecare partidă disputată aici este o oportunitate pentru juniorii noștri să impresioneze și să-și construiască drumul spre performanță.\n\nSuporterii care vin pe Unirea U21 Stadium creează o atmosferă caldă și încurajatoare, ajutând echipa să se simtă mereu susținută, indiferent de rezultat. Stadionul reprezintă un punct de pornire spre cariere de succes pentru mulți jucători crescuți la FC Unirea.\n\nMult succes în noul sezon, Unirea U21!\nHai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3993), "FC Unirea Youth își dispută meciurile de acasă pe **Unirea Youth Stadium**, situat în Odobești.\n\nAcest stadion, cu o capacitate de 10 locuri, este locul unde copiii și adolescenții clubului fac primii pași în fotbalul organizat. Pentru mulți dintre ei, Unirea Youth Stadium reprezintă locul unde pasiunea pentru fotbal se transformă în visuri, prietenii și primele reușite sportive.\n\nFiecare meci disputat aici este o oportunitate de a învăța, de a se bucura de fotbal și de a construi viitorul clubului. Atmosfera este mereu caldă, iar suporterii prezenți îi încurajează pe tinerii jucători la fiecare pas.\n\nHai, Unirea Youth!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3994), "La fiecare meci disputat pe **Unirea Stadium** din Odobești, suporterii au la dispoziție o gamă variată de locuri, atât pentru cei care preferă confortul maxim, cât și pentru cei care vor să simtă pulsul tribunei alături de ceilalți fani.\n\n**Locuri disponibile:**  \n- VIP: A1, A2 (preț: 150 lei/bilet)  \n- Standard: B1, B2, C1, C2, D1, D2, E1, E2 (preț: 50 lei/bilet)  \n\nIndiferent de tipul biletului ales, fiecare suporter contribuie la atmosfera specială de pe stadion și la susținerea echipei. Vă așteptăm la fiecare meci să vă bucurați de fotbal și să susțineți FC Unirea din tribunele noastre!" });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "UsersId", "Text", "Title" },
                values: new object[,]
                {
                    { 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3995), 1, "Pe 8 mai 2025, FC Unirea Youth a terminat la egalitate, scor 2-2, cu Youth Galați, într-un meci palpitant din Liga 1 Tineret.\n\nPentru echipa noastră au marcat Paul Rădulescu și Alex Vasilescu, în timp ce pentru oaspeți au înscris Florin Neagu și Andrei Petrescu.\n\nA fost un meci plin de faze de poartă, determinare și spirit de luptă din partea ambelor formații. Bravo tinerilor pentru atitudine!\n\nHai, Unirea Youth!", "Remiză spectaculoasă pentru FC Unirea Youth cu Youth Galați!" },
                    { 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3996), 1, "Pe 8 mai 2025, FC Unirea a obținut o victorie răsunătoare cu scorul de 4-1 împotriva echipei Steaua Sud, în Liga 1.\n\nGolurile echipei noastre au fost marcate de Daniel Stan, Denis Ilie, Denis Chiriac și George Ilie, în timp ce pentru oaspeți a înscris Vlad Chiriac.\n\nA fost o demonstrație de forță și eficiență din partea băieților noștri, cu un atac excelent și o defensivă solidă. Felicitări echipei pentru spectacol!\n\nHai, Unirea!", "FC Unirea, victorie clară cu Steaua Sud în Liga 1!" },
                    { 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3997), 1, "Pe 7 mai 2025, FC Unirea a învins în deplasare, scor 2-0, pe CS Mioveni, într-un meci din Cupa României.\n\nIonuț Rădulescu a marcat unul dintre goluri, iar echipa a arătat o prestație solidă, calificându-se mai departe în competiție.\n\nFelicitări băieților pentru evoluția foarte bună și pentru parcursul în Cupă!\n\nHai, Unirea!", "FC Unirea câștigă în Cupa României pe terenul CS Mioveni!" },
                    { 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3999), 1, "Pe 7 mai 2025, FC Unirea a terminat la egalitate, scor 2-2, cu Steaua Belgrad, într-un meci intens din Champions League.\n\nAlex Vasilescu și Denis Neagu au înscris pentru FC Unirea, iar pentru oaspeți au punctat Nikola Mitrovic și Aleksandar Radovanovic.\n\nUn duel spectaculos, cu multe faze de poartă și un public extraordinar. Felicitări jucătorilor pentru determinare și pentru punctul obținut în fața unei echipe de top!\n\nHai, Unirea!", "Spectacol total: FC Unirea și Steaua Belgrad, remiză în Champions League!" },
                    { 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4000), 1, "Pe 1 mai 2025, FC Unirea s-a impus cu scorul de 2-1 în fața celor de la CS Mioveni, într-un meci disputat în Liga 1.\n\nPentru FC Unirea au marcat Denis Chiriac și Ștefan Popescu, iar pentru adversari a înscris Radu Ionescu.\n\nMeciul a fost dinamic și disputat, cu un final fericit pentru echipa noastră. Felicitări băieților pentru victorie!\n\nHai, Unirea!", "FC Unirea începe luna mai cu victorie contra CS Mioveni!" },
                    { 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4001), 1, "Pe 21 mai 2025, FC Unirea a pierdut cu 3-0 în fața lui Juventus, într-un meci din grupele Champions League.\n\nPentru italieni au înscris Marco Rossi, Alessandro Esposito și Simone Marino.\n\nDeși scorul nu ne avantajează, echipa noastră va continua lupta pentru calificare!\n\nHai, Unirea!", "Înfrângere pentru FC Unirea pe terenul lui Juventus, în Champions League" },
                    { 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4002), 1, "Pe 15 mai 2025, FC Unirea a câștigat cu 1-0 pe terenul celor de la Dinamo Est, într-un meci disputat în Liga 1.\n\nUnicul gol al partidei a fost marcat de Andrei Neagu, care a adus 3 puncte echipei noastre.\n\nFelicitări băieților pentru efort și dăruire!\n\nHai, Unirea!", "Victorie la limită pentru FC Unirea contra Dinamo Est!" },
                    { 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4003), 1, "Pe 15 mai 2025, FC Unirea Youth a terminat la egalitate, scor 2-2, pe terenul celor de la Youth Hunedoara, într-un meci din Liga 1 Tineret.\n\nPentru gazde au marcat Cristian Neagu și Daniel Popescu, iar pentru echipa noastră au înscris Alin Ionescu și Ionuț Diaconu.\n\nA fost un meci cu multe faze de poartă și suspans până la final. Felicitări tinerilor pentru atitudine!\n\nHai, Unirea Youth!", "Remiză spectaculoasă între Youth Hunedoara și FC Unirea Youth!" },
                    { 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4004), 1, "Pe 15 mai 2025, FC Unirea U21 a obținut o victorie cu 2-0 pe terenul celor de la U21 Farul, în Liga 1 U21.\n\nGolurile victoriei au fost marcate de Sergiu Neagu și Sergiu Rădulescu.\n\nBăieții continuă seria de meciuri bune și urcă în clasament!\n\nHai, Unirea U21!", "FC Unirea U21 se impune în deplasare cu U21 Farul!" },
                    { 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4005), 1, "Pe 8 mai 2025, FC Unirea U21 a pierdut cu 2-0 în fața celor de la U21 Voluntari, într-un meci din Liga 1 U21.\n\nPentru oaspeți au înscris Paul Neagu și Daniel Popescu.\n\nBăieții au luptat până la final, dar norocul nu a fost de partea noastră de această dată.\n\nHai, Unirea U21!", "Eșec pe teren propriu pentru FC Unirea U21 cu U21 Voluntari" },
                    { 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4006), 1, "Pe 29 mai 2025, FC Unirea U21 a pierdut cu 2-1 în fața echipei U21 Poli Iași, într-un meci din Liga 1 U21.\n\nPentru gazde a marcat Ștefan Diaconu, iar pentru FC Unirea U21 a punctat Eduard Diaconu.\n\nUn meci disputat, cu ocazii de ambele părți. Băieții noștri au luptat până la final!\n\nHai, Unirea U21!", "Înfrângere la limită pentru FC Unirea U21 în deplasare la U21 Poli Iași" },
                    { 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4054), 1, "Pe 29 mai 2025, FC Unirea Youth a pierdut cu scorul de 3-1 pe terenul celor de la Youth Vaslui, într-un meci din Liga 1 Tineret.\n\nPentru echipa noastră a marcat Ionuț Neagu, iar pentru gazde a înscris George Voicu.\n\nTinerii noștri au avut momente bune, dar gazdele s-au impus până la final. Capul sus, băieți!\n\nHai, Unirea Youth!", "FC Unirea Youth învinsă de Youth Vaslui în Liga 1 Tineret" },
                    { 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4057), 1, "Pe 22 mai 2025, FC Unirea a pierdut cu scorul de 2-1 pe teren propriu în fața Rapid Nord, într-un meci disputat în Liga 1.\n\nAlex Lazăr a marcat pentru FC Unirea, iar pentru oaspeți a înscris Cristian Enache.\n\nUn meci cu multe ocazii, în care am avut ghinion. Hai, Unirea, nu renunțăm!\n\nHai, Unirea!", "FC Unirea pierde acasă cu Rapid Nord, după un meci strâns" },
                    { 32, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4058), 1, "Pe 22 mai 2025, FC Unirea U21 a remizat 0-0 cu U21 Sepsi, într-un meci echilibrat din Liga 1 U21.\n\nDeși nu s-au marcat goluri, meciul a fost disputat și cu multe ocazii la ambele porți.\n\nFelicitări băieților pentru efort!\n\nHai, Unirea U21!", "Remiză albă între FC Unirea U21 și U21 Sepsi în Liga 1 U21" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "CreatedAt", "UsersId", "Text", "Title" },
                values: new object[,]
                {
                    { 33, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4059), 1, "Pe 22 mai 2025, FC Unirea Youth a fost învinsă cu 1-0 de Youth Târgoviște, într-un meci din Liga 1 Tineret.\n\nA fost un meci echilibrat, dar adversarii au reușit să înscrie unicul gol al partidei.\n\nTinerii noștri au dat totul pe teren și merită felicitări pentru efort!\n\nHai, Unirea Youth!", "FC Unirea Youth pierde la limită cu Youth Târgoviște" },
                    { 34, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4060), 1, "Pe 4 iunie 2025, FC Unirea a învins cu scorul de 2-1 pe Dinamo Zagreb, într-un meci disputat în Champions League.\n\nGolurile victoriei au fost marcate de Andrei Neagu și Daniel Rădulescu pentru FC Unirea, în timp ce pentru oaspeți a înscris Ivan Kovacic.\n\nEchipa a avut o evoluție excelentă și adaugă încă 3 puncte în grupa europeană!\n\nHai, Unirea!", "FC Unirea obține o victorie importantă cu Dinamo Zagreb în Champions League!" },
                    { 35, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4061), 1, "Pe 1 iunie 2025, FC Unirea s-a impus cu 4-0 în fața echipei Steaua Sud, într-un meci din Cupa României.\n\nPentru echipa noastră au marcat Alex Lazăr, Alin Neagu, Robert Vasilescu și George Ilie.\n\nA fost un meci dominat de la un capăt la altul, cu o defensivă solidă și un atac de neoprit. Felicitări echipei pentru calificare!\n\nHai, Unirea!", "Calificare categorică: FC Unirea câștigă cu Steaua Sud în Cupa României!" },
                    { 36, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4061), 1, "Pe 29 mai 2025, FC Unirea a terminat la egalitate, scor 1-1, pe terenul Petrolul Vest, într-un meci din Liga 1.\n\nPentru gazde a marcat Vlad Voicu, iar pentru FC Unirea a înscris Denis Chiriac.\n\nA fost un meci echilibrat, cu ocazii de ambele părți. Continuăm lupta pentru locurile fruntașe!\n\nHai, Unirea!", "Remiză între FC Unirea și Petrolul Vest în Liga 1" },
                    { 37, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4062), 1, "Pe 13 iunie 2025, FC Unirea a pierdut cu scorul de 3-0 pe terenul celor de la CSM Cluj, într-un meci din Liga 1.\n\nPentru gazde au marcat Mihai Ionescu, Denis Voicu și Gabriel Rădulescu.\n\nEchipa noastră va încerca să revină cu un rezultat pozitiv în următoarea etapă.\n\nHai, Unirea!", "Înfrângere pentru FC Unirea la CSM Cluj în Liga 1" },
                    { 38, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4064), 1, "Pe 13 iunie 2025, FC Unirea U21 a remizat 1-1 în deplasare cu U21 Argeș, într-un meci din Liga 1 U21.\n\nPentru gazde a marcat George Popescu, iar pentru FC Unirea U21 a punctat Denis Cojocaru.\n\nA fost un meci echilibrat, cu șanse de ambele părți.\n\nHai, Unirea U21!", "Remiză între U21 Argeș și FC Unirea U21 în Liga 1 U21" },
                    { 39, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4065), 1, "Pe 13 iunie 2025, FC Unirea Youth a terminat la egalitate, scor 2-2, în deplasare la Youth Craiova, într-un meci din Liga 1 Tineret.\n\nPentru echipa noastră a marcat Ionuț Diaconu, iar pentru adversari a înscris Andrei Enache.\n\nUn rezultat bun, cu evoluții solide de ambele părți.\n\nHai, Unirea Youth!", "FC Unirea Youth scoate un egal la Youth Craiova în Liga 1 Tineret" },
                    { 40, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4066), 1, "Pe 8 iunie 2025, FC Unirea a remizat 0-0 în deplasare la Steaua Sud, într-un meci fără goluri în Cupa României.\n\nMeci echilibrat, cu ocazii de ambele părți, dar fără reușite pe tabelă.\n\nHai, Unirea!", "Remiză albă între Steaua Sud și FC Unirea în Cupa României" },
                    { 41, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4067), 1, "Pe 6 iunie 2025, FC Unirea a remizat 1-1 cu Universitatea Brașov, într-un meci disputat în Liga 1.\n\nPentru gazde a marcat Alex Vasilescu, iar pentru oaspeți a înscris Alin Ionescu.\n\nMeci echilibrat, ambele echipe au arătat fotbal de calitate.\n\nHai, Unirea!", "FC Unirea și Universitatea Brașov termină la egalitate în Liga 1" },
                    { 42, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4068), 1, "Pe 6 iunie 2025, FC Unirea U21 a pierdut cu 2-0 pe teren propriu cu U21 UTA, într-un meci din Liga 1 U21.\n\nPentru oaspeți au înscris Vlad Stan și Alin Enache.\n\nBăieții noștri au luptat, dar nu au reușit să marcheze de această dată.\n\nHai, Unirea U21!", "Înfrângere pe teren propriu pentru FC Unirea U21 cu U21 UTA" },
                    { 43, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4069), 1, "Pe 6 iunie 2025, FC Unirea Youth a pierdut cu 1-0 în fața echipei Youth Baia Mare, într-un meci din Liga 1 Tineret.\n\nUnicul gol al partidei a fost marcat de Vlad Ionescu.\n\nTinerii noștri au dat totul pe teren, dar norocul nu a fost de partea noastră.\n\nHai, Unirea Youth!", "FC Unirea Youth, învinsă la limită de Youth Baia Mare" },
                    { 44, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4070), 1, "Pe 27 iunie 2025, FC Unirea U21 a terminat la egalitate, scor 0-0, cu U21 Botoșani, într-un meci din Liga 1 U21.\n\nA fost un meci echilibrat, fără goluri, dar cu multe faze de poartă de ambele părți.\n\nHai, Unirea U21!", "Remiză albă pentru FC Unirea U21 la U21 Botoșani" },
                    { 45, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4071), 1, "Pe 27 iunie 2025, FC Unirea Youth a obținut o victorie cu 2-0 pe terenul celor de la Youth Oradea, într-un meci din Liga 1 Tineret.\n\nVlad Ionescu a marcat pentru echipa noastră, aducând trei puncte importante.\n\nFelicitări tinerilor pentru efort și atitudine!\n\nHai, Unirea Youth!", "FC Unirea Youth câștigă la Oradea în Liga 1 Tineret!" },
                    { 46, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4072), 1, "Pe 27 iunie 2025, FC Unirea a câștigat cu 2-1 pe terenul Viitorul Constanța, într-un meci disputat în Liga 1.\n\nPentru gazde a marcat Gabriel Vasilescu, iar pentru FC Unirea au înscris Denis Chiriac și Alex Vasilescu.\n\nUn meci spectaculos, cu răsturnări de scor și un final fericit pentru echipa noastră.\n\nHai, Unirea!", "FC Unirea se impune în deplasare la Viitorul Constanța!" },
                    { 47, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4073), 1, "Pe 20 iunie 2025, FC Unirea a remizat 0-0 cu Gloria Buzău, într-un meci echilibrat din Liga 1.\n\nDeși nu s-au marcat goluri, meciul a fost disputat și cu ocazii de ambele părți.\n\nHai, Unirea!", "Remiză fără goluri între FC Unirea și Gloria Buzău în Liga 1" },
                    { 48, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4074), 1, "Pe 20 iunie 2025, FC Unirea Youth a pierdut cu scorul de 3-1 pe teren propriu cu Youth Ploiești, într-un meci din Liga 1 Tineret.\n\nSingurul gol al echipei noastre a fost marcat de Andrei Ionescu.\n\nBăieții au dat totul pe teren și merită încurajări pentru efort!\n\nHai, Unirea Youth!", "Înfrângere pentru FC Unirea Youth cu Youth Ploiești" },
                    { 49, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4075), 1, "Pe 20 iunie 2025, FC Unirea U21 a câștigat cu scorul de 3-0 împotriva celor de la U21 Hermannstadt, într-un meci disputat în Liga 1 U21.\n\nPentru echipa noastră au marcat Alin Voicu și Sergiu Neagu.\n\nO victorie clară, cu un joc solid pe toate compartimentele.\n\nHai, Unirea U21!", "FC Unirea U21 învinge clar pe U21 Hermannstadt în Liga 1 U21!" },
                    { 50, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4076), 1, "Pe 18 iunie 2025, FC Unirea a fost învinsă cu scorul de 2-0 pe terenul celor de la Paris Saint-Germain, într-un meci disputat în Champions League.\n\nPentru gazde a marcat Laurent Moreau, iar pentru FC Unirea a punctat Alin Neagu.\n\nEchipa noastră merge mai departe cu capul sus și speră la o revanșă acasă!\n\nHai, Unirea!", "FC Unirea cedează la Paris cu PSG în Champions League" },
                    { 51, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4077), 1, "Pe 7 iulie 2025, FC Unirea s-a impus cu scorul de 3-2 pe terenul celor de la Dinamo Est, într-un meci dramatic din Cupa României.\n\nGolurile echipei noastre au fost marcate de Andrei Neagu, Alex Vasilescu și Daniel Stan.\n\nBravo băieților pentru calificare și determinare!\n\nHai, Unirea!", "FC Unirea trece de Dinamo Est în Cupa României, la capătul unui meci spectaculos!" },
                    { 52, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4078), 1, "Pe 4 iulie 2025, FC Unirea a pierdut cu scorul de 2-0 pe terenul celor de la CS Mioveni, într-un meci din Liga 1.\n\nPentru gazde au marcat Daniel Ilie și Gabriel Chiriac.\n\nEchipa noastră va căuta revanșa în etapele următoare.\n\nHai, Unirea!", "FC Unirea, înfrântă la CS Mioveni în Liga 1" },
                    { 53, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4079), 1, "Pe 4 iulie 2025, FC Unirea Youth a câștigat cu scorul de 1-0 pe terenul celor de la Youth Arad, într-un meci din Liga 1 Tineret.\n\nTinerii noștri au obținut o victorie muncită, demonstrând caracter și ambiție.\n\nFelicitări tuturor jucătorilor!\n\nHai, Unirea Youth!", "Victorie pentru FC Unirea Youth la Arad!" },
                    { 54, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4080), 1, "Pe 4 iulie 2025, FC Unirea U21 a câștigat cu scorul de 2-0 în deplasare la U21 Slatina, într-un meci disputat în Liga 1 U21.\n\nEchipa noastră a dominat jocul și a obținut trei puncte importante.\n\nHai, Unirea U21!", "FC Unirea U21 câștigă la U21 Slatina în Liga 1 U21!" },
                    { 55, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4081), 1, "Pe 2 iulie 2025, FC Unirea a remizat 1-1 cu Olympiakos, într-un meci disputat în grupele Champions League.\n\nPentru FC Unirea a înscris Sergiu Chiriac, iar pentru greci a marcat Marios Retsos.\n\nUn punct important în economia grupei. Felicitări băieților pentru efort!\n\nHai, Unirea!", "FC Unirea și Olympiakos, remiză în Champions League!" },
                    { 56, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4082), 1, "Pe 1 iulie 2025, FC Unirea a învins cu 3-0 pe Dinamo Est, într-un meci din Cupa României.\n\nGolurile echipei noastre au fost marcate de Denis Ilie, Gabriel Vasilescu și Radu Ilie.\n\nEchipa merge mai departe cu un moral excelent!\n\nHai, Unirea!", "FC Unirea câștigă clar cu Dinamo Est în Cupa României!" }
                });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "FC Unirea a fost fondată în anul 1923, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\n\nEchipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016. ");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. Echipa a luat naștere în anul 1993, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\n\nÎncă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\n\nPrin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice. ");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. Echipa a fost creată în anul 1990 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\n\nScopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\n\nPrin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune. ");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2974));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2979));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2980));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2981));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2983));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2984));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2985));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2986));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2988));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2990));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2991));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2994));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2995));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2997));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2998));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(2999));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3000));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3002));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3003));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3004));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3006));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3007));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3008));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3009));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3010));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3012));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3013));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3017));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3018));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3019));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3020));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3021));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3023));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3024));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3025));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3026));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3027));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3028));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3030));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3031));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3033));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3077));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3079));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3081));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3082));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3083));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3084));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3085));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3086));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3087));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3089));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3090));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3091));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3093));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3094));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3095));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3096));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3097));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3098));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3099));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3101));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3102));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3103));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3104));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3106));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3108));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3109));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3110));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3112));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3113));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3114));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3116));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3117));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3118));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3119));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3120));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3121));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3123));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3124));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3125));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3126));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3127));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3128));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3129));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3130));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3132));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3133));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3134));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3135));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3139));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3140));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3141));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3142));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3144));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3145));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3146));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3147));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3148));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3149));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3151));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3152));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3153));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3154));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3155));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3156));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3157));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3197));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3198));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3199));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3200));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3203));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3204));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3205));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3206));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3207));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3208));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3209));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3211));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3212));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3213));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3214));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3216));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3217));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3218));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3219));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3220));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3221));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3222));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3223));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(3224));

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 151, 19, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4503), "Un meci intens, bravo băieți!" },
                    { 152, 19, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4505), "Remiză muncită, continuați tot așa!" },
                    { 153, 19, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4506), "Paul și Alex, de urmărit pe viitor!" },
                    { 154, 19, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4507), "Frumos joc, să vină și victoriile!" },
                    { 155, 19, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4508), "Atmosferă bună, tineri talentați!" },
                    { 156, 20, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4510), "Ce meci! 4 goluri, respect!" },
                    { 157, 20, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4511), "Bravo FC Unirea, victorie clară!" },
                    { 158, 20, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4512), "Daniel Stan și Denis Ilie, super jucători!" },
                    { 159, 20, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4513), "Așa vrem să vă vedem în fiecare meci!" },
                    { 160, 20, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4514), "Felicitări băieți, spectacol total!" },
                    { 161, 21, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4516), "Excelent în Cupă, țineți-o tot așa!" },
                    { 162, 21, 1, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4517), "Ionuț Rădulescu din nou decisiv!" },
                    { 163, 21, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4518), "Felicitări pentru calificare!" },
                    { 164, 21, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4520), "Apărare de fier, bravo Unirea!" },
                    { 165, 21, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4521), "Cupa e aproape, hai băieți!" },
                    { 166, 22, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4522), "Spectacol în Champions League!" },
                    { 167, 22, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4523), "Remiză bună cu o echipă puternică!" },
                    { 168, 22, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4524), "Alex Vasilescu și Denis Neagu, excepționali!" },
                    { 169, 22, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4526), "Bravo băieți, ați luptat până la capăt!" },
                    { 170, 22, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4527), "Vrem să vă vedem în optimi!" },
                    { 171, 23, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4528), "Victorie importantă pentru moral!" },
                    { 172, 23, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4529), "Denis Chiriac și Ștefan Popescu, bravo!" },
                    { 173, 23, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4530), "Încă trei puncte, să urcăm în clasament!" },
                    { 174, 23, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4531), "Echipa joacă din ce în ce mai bine!" },
                    { 175, 23, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4532), "Să vină următoarea victorie!" },
                    { 176, 24, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4533), "Nu renunțăm, încă avem șanse!" },
                    { 177, 24, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4534), "Juventus a fost prea puternică azi." },
                    { 178, 24, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4535), "Hai Unirea, capul sus!" },
                    { 179, 24, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4536), "Așteptăm revanșa pe teren propriu!" },
                    { 180, 24, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4537), "Credem în voi până la final!" },
                    { 181, 25, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4538), "Trei puncte muncite, felicitări!" },
                    { 182, 25, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4539), "Andrei Neagu, eroul nostru!" },
                    { 183, 25, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4540), "Bravo băieți, continuăm seria bună!" },
                    { 184, 25, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4542), "Forța Unirea, urcăm în clasament!" },
                    { 185, 25, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4543), "Victorie importantă pentru moral!" },
                    { 186, 26, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4544), "Super meci, emoții până la final!" },
                    { 187, 26, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4545), "Bravo, Unirea Youth!" },
                    { 188, 26, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4546), "Alin și Ionuț, de viitor!" },
                    { 189, 26, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4548), "Remiză echitabilă, ambele echipe au luptat!" },
                    { 190, 26, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4549), "Hai Unirea, la mai multe goluri!" },
                    { 191, 27, 1, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4550), "Victorie clară, felicitări U21!" },
                    { 192, 27, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4551), "Sergiu Neagu și Radulescu, super goluri!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 193, 27, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4552), "Meci foarte bun în deplasare!" },
                    { 194, 27, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4553), "Felicitări tuturor pentru efort!" },
                    { 195, 27, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4554), "Forța Unirea U21!" },
                    { 196, 28, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4556), "Capul sus, băieți! Vor veni și victoriile!" },
                    { 197, 28, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4557), "U21 Voluntari a fost mai bună azi." },
                    { 198, 28, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4558), "Ne revenim la următorul meci!" },
                    { 199, 28, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4559), "Hai Unirea U21!" },
                    { 200, 28, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4560), "Nu renunțăm, suntem alături de voi!" },
                    { 201, 29, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4561), "Băieții au luptat frumos!" },
                    { 202, 29, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4562), "Eduard Diaconu a făcut un meci bun!" },
                    { 203, 29, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4563), "Meci greu, capul sus!" },
                    { 204, 29, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4564), "Felicitări pentru atitudine, mergem mai departe!" },
                    { 205, 29, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4565), "Nu renunțăm, Unirea U21!" },
                    { 206, 30, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4566), "A fost greu la Vaslui, dar avem potențial!" },
                    { 207, 30, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4567), "Bravo Ionuț Neagu pentru gol!" },
                    { 208, 30, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4568), "Hai Unirea Youth, revenim la următorul meci!" },
                    { 209, 30, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4569), "Tinerii merită încurajați mereu!" },
                    { 210, 30, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4570), "Capul sus, se poate mai bine!" },
                    { 211, 31, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4571), "Meci bun, păcat de rezultat!" },
                    { 212, 31, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4572), "Alex Lazăr a arătat calitate!" },
                    { 213, 31, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4573), "Rapid Nord ne-a surprins azi." },
                    { 214, 31, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4574), "Nu e nimic, continuăm lupta!" },
                    { 215, 31, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4575), "Hai Unirea, credem în voi!" },
                    { 216, 32, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4577), "Meci echilibrat, portar bun!" },
                    { 217, 32, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4578), "0-0, dar echipa a jucat bine." },
                    { 218, 32, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4579), "Felicitări pentru efort!" },
                    { 219, 32, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4580), "Ne vedem la următorul meci!" },
                    { 220, 32, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4581), "Un punct e mai bun decât nimic!" },
                    { 221, 33, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4582), "Tinerii s-au ținut bine!" },
                    { 222, 33, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4583), "Meci echilibrat, ghinion la final." },
                    { 223, 33, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4584), "Felicitări pentru efort!" },
                    { 224, 33, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4586), "Hai Unirea Youth, mergem înainte!" },
                    { 225, 33, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4624), "Public frumos, mulțumim pentru susținere!" },
                    { 226, 34, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4627), "Victorie de moral, bravo băieți!" },
                    { 227, 34, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4627), "Andrei Neagu a făcut diferența din nou!" },
                    { 228, 34, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4629), "Super meci, trei puncte importante!" },
                    { 229, 34, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4630), "Forța Unirea în Europa!" },
                    { 230, 34, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4631), "Felicitări întregii echipe pentru efort!" },
                    { 231, 35, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4632), "Ce spectacol! Felicitări băieților!" },
                    { 232, 35, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4633), "Patru goluri, apărare perfectă!" },
                    { 233, 35, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4634), "Vrem trofeul în acest an!" },
                    { 234, 35, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4635), "Alex Lazăr și George Ilie, de nota 10!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 235, 35, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4636), "Felicitări și staff-ului tehnic!" },
                    { 236, 36, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4637), "Meci echilibrat, am fi meritat victoria." },
                    { 237, 36, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4639), "Bravo Denis Chiriac pentru gol!" },
                    { 238, 36, 1, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4640), "Hai Unirea, luptați până la final!" },
                    { 239, 36, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4641), "Un punct câștigat, mergem înainte!" },
                    { 240, 36, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4642), "Încă un pas spre play-off!" },
                    { 241, 37, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4643), "Capul sus, urmează alte meciuri!" },
                    { 242, 37, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4644), "CSM Cluj a fost în formă azi." },
                    { 243, 37, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4645), "Hai Unirea, revenim cu victorie!" },
                    { 244, 37, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4646), "Trebuie să strângem rândurile!" },
                    { 245, 37, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4647), "Ne vedem la următorul meci!" },
                    { 246, 38, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4648), "Remiză bună în deplasare!" },
                    { 247, 38, 1, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4649), "Denis Cojocaru, felicitări pentru gol!" },
                    { 248, 38, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4650), "Un punct câștigat, urcăm în clasament!" },
                    { 249, 38, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4651), "Bravo băieți, continuăm seria bună!" },
                    { 250, 38, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4652), "Hai Unirea U21!" },
                    { 251, 39, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4653), "Ionuț Diaconu a fost în mare formă!" },
                    { 252, 39, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4654), "Un egal meritat pentru ambele echipe!" },
                    { 253, 39, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4655), "Bravo Unirea Youth!" },
                    { 254, 39, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4656), "Felicitări pentru rezultat!" },
                    { 255, 39, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4657), "Continuăm cu aceeași atitudine!" },
                    { 256, 40, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4658), "Remiză bună în deplasare!" },
                    { 257, 40, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4659), "Apărarea a funcționat perfect azi!" },
                    { 258, 40, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4660), "Hai Unirea, se poate mai mult!" },
                    { 259, 40, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4661), "Meci bun, fără goluri." },
                    { 260, 40, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4662), "Continuăm drumul spre trofeu!" },
                    { 261, 41, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4663), "Egal echitabil, bun pentru moral!" },
                    { 262, 41, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4664), "Alex Vasilescu, gol frumos!" },
                    { 263, 41, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4665), "Universitatea Brașov a jucat bine!" },
                    { 264, 41, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4667), "Hai Unirea, urmează victoriile!" },
                    { 265, 41, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4668), "Felicitări băieților pentru efort!" },
                    { 266, 42, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4669), "U21 UTA a fost mai bună azi." },
                    { 267, 42, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4670), "Băieții au dat totul pe teren!" },
                    { 268, 42, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4671), "Capul sus, Unirea U21!" },
                    { 269, 42, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4672), "Ne revanșăm la următorul meci!" },
                    { 270, 42, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4673), "Hai Unirea U21, suntem cu voi!" },
                    { 271, 43, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4674), "Băieții au muncit, păcat de rezultat." },
                    { 272, 43, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4675), "Youth Baia Mare a fost pragmatică." },
                    { 273, 43, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4676), "Hai Unirea Youth, revenim la victorie!" },
                    { 274, 43, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4677), "Atmosferă frumoasă la stadion!" },
                    { 275, 43, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4678), "Tinerii au nevoie de susținere!" },
                    { 276, 44, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4679), "Un punct muncit în deplasare!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 277, 44, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4680), "Băieții au dat totul!" },
                    { 278, 44, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4681), "Bravo Unirea U21!" },
                    { 279, 44, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4682), "Felicitări pentru efort!" },
                    { 280, 44, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4684), "Hai Unirea U21 la următorul meci!" },
                    { 281, 45, 1, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4686), "Super victorie la Oradea!" },
                    { 282, 45, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4687), "Felicitări Vlad Ionescu pentru gol!" },
                    { 283, 45, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4688), "Tinerii arată bine sezonul acesta!" },
                    { 284, 45, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4689), "Hai Unirea Youth, mergeți înainte!" },
                    { 285, 45, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4690), "Bravo tuturor pentru atitudine!" },
                    { 286, 46, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4691), "Victorie meritată la Constanța!" },
                    { 287, 46, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4692), "Denis Chiriac, Alex Vasilescu – super joc!" },
                    { 288, 46, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4693), "Felicitări echipei pentru efort!" },
                    { 289, 46, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4694), "Un meci cu multe emoții!" },
                    { 290, 46, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4695), "Hai Unirea, la cât mai multe victorii!" },
                    { 291, 47, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4696), "Un punct câștigat cu Buzău!" },
                    { 292, 47, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4697), "Portarii au fost la post!" },
                    { 293, 47, 30, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4698), "Meci echilibrat, ne vedem la următorul!" },
                    { 294, 47, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4699), "Hai Unirea!" },
                    { 295, 47, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4700), "Capul sus, băieți!" },
                    { 296, 48, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4701), "Nu-i nimic, băieții au dat totul!" },
                    { 297, 48, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4702), "Felicitări Andrei Ionescu pentru gol!" },
                    { 298, 48, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4703), "Hai Unirea Youth, ne revenim la următorul!" },
                    { 299, 48, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4704), "Trebuie să avem încredere în tineri!" },
                    { 300, 48, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4705), "Atmosferă frumoasă pe stadion!" },
                    { 301, 49, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4706), "Victorie clară, felicitări U21!" },
                    { 302, 49, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4707), "Alin Voicu și Sergiu Neagu – decisivi!" },
                    { 303, 49, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4708), "Meci perfect, băieții au jucat bine!" },
                    { 304, 49, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4709), "Să continuăm tot așa!" },
                    { 305, 49, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4710), "Hai Unirea U21!" },
                    { 306, 50, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4711), "Meci greu la Paris, continuăm lupta!" },
                    { 307, 50, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4712), "Bravo Alin Neagu pentru gol!" },
                    { 308, 50, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4713), "Hai Unirea, credem în voi!" },
                    { 309, 50, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4750), "PSG e o echipă grea, felicitări pentru atitudine!" },
                    { 310, 50, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4753), "Așteptăm revanșa pe teren propriu!" },
                    { 311, 51, 17, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4754), "Ce meci nebun! Bravo Unirea!" },
                    { 312, 51, 6, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4755), "Calificare meritată, felicitări băieți!" },
                    { 313, 51, 12, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4756), "Andrei Neagu, decisiv ca de obicei!" },
                    { 314, 51, 29, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4757), "Trei goluri superbe!" },
                    { 315, 51, 23, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4758), "Hai Unirea în semifinale!" },
                    { 316, 52, 2, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4759), "Păcat de rezultat, dar mergem înainte!" },
                    { 317, 52, 26, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4760), "CS Mioveni a profitat de ocazii." },
                    { 318, 52, 5, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4761), "Hai Unirea, ne revenim!" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "NewsId", "UserId", "CreatedAt", "Text" },
                values: new object[,]
                {
                    { 319, 52, 19, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4762), "Capul sus, băieți!" },
                    { 320, 52, 21, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4763), "Ne vedem pe stadion la următorul meci." },
                    { 321, 53, 15, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4764), "Victorie muncită, bravo Youth!" },
                    { 322, 53, 4, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4765), "Felicitări pentru cele 3 puncte!" },
                    { 323, 53, 13, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4769), "Tinerii promit mult!" },
                    { 324, 53, 24, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4770), "Hai Unirea Youth!" },
                    { 325, 53, 31, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4771), "Atmosferă frumoasă la Arad!" },
                    { 326, 54, 27, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4772), "Victorie clară pentru U21, felicitări!" },
                    { 327, 54, 8, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4773), "Meci foarte bun al băieților!" },
                    { 328, 54, 11, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4774), "Hai Unirea U21, susținem echipa!" },
                    { 329, 54, 3, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4775), "Trei puncte uriașe în deplasare!" },
                    { 330, 54, 28, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4776), "Continuăm seria bună!" },
                    { 331, 55, 1, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4777), "Remiză utilă în grupele Champions League!" },
                    { 332, 55, 25, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4778), "Felicitări Sergiu Chiriac pentru gol!" },
                    { 333, 55, 18, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4779), "Olympiakos, adversar puternic!" },
                    { 334, 55, 10, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4780), "Hai Unirea, credem în calificare!" },
                    { 335, 55, 14, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4781), "Un punct important, felicitări!" },
                    { 336, 56, 7, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4782), "Felicitări pentru calificare!" },
                    { 337, 56, 16, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4783), "Trei goluri și fără gol primit!" },
                    { 338, 56, 9, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4784), "Denis Ilie din nou decisiv!" },
                    { 339, 56, 22, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4785), "Bravo echipei, se simte progresul!" },
                    { 340, 56, 20, new DateTime(2025, 6, 1, 10, 0, 6, 817, DateTimeKind.Utc).AddTicks(4786), "Hai Unirea spre trofeu!" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "News",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Comments",
                type: "TEXT",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(MAX)",
                oldMaxLength: 300);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "UserId", "CreatedAt", "Text" },
                values: new object[] { 9, new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2890), "Comentariu de la user 9 pentru știrea 1." });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2864), "FC Unirea este încântată să anunțe participarea în trei competiții importante în sezonul acesta: Liga 1, Cupa României și Champions League.\r\n        \r\n                    Participarea în **Liga 1** aduce un nou prilej pentru echipa noastră de a lupta pentru titlul național, alături de cele mai bune echipe din țară.\r\n\r\n                    În **Cupa României**, obiectivul nostru este să mergem cât mai departe în competiție și să aducem suporterilor momente de neuitat.\r\n\r\n                    Nu în ultimul rând, prezența în **Champions League** reprezintă un vis devenit realitate! Este o șansă uriașă pentru echipă de a se confrunta cu formații de top din Europa, de a acumula experiență și de a duce numele FC Unirea pe cele mai mari stadioane.\r\n\r\n                    Vă invităm să fiți alături de noi în acest sezon de excepție! Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2867), "Echipa FC Unirea U21 va concura exclusiv în Liga 1 U21 în acest sezon, o competiție dedicată tinerilor talentați care fac parte din generația viitorului.\r\n\r\n                    Liga 1 U21 reprezintă o oportunitate excelentă pentru jucătorii noștri să-și demonstreze abilitățile și să facă pasul spre echipa mare. Antrenorii și staff-ul tehnic sunt încrezători că tinerii vor aduce rezultate bune și vor evolua de la meci la meci.\r\n\r\n                    Obiectivul principal este dezvoltarea jucătorilor, promovarea valorilor clubului și pregătirea lor pentru a face față provocărilor fotbalului de performanță.\r\n\r\n                    Susțineți FC Unirea U21 în această nouă aventură fotbalistică! Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2868), "Avem bucuria să anunțăm că echipa FC Unirea Youth va evolua în acest sezon în **Liga 1 de tineret**!\r\n\r\n                    Această competiție este dedicată tinerilor fotbaliști cu potențial, care se pregătesc pentru pasul următor în cariera lor sportivă. Obiectivul clubului este să descopere noi talente și să le ofere oportunitatea de a juca la nivel înalt încă de la o vârstă fragedă.\r\n\r\n                    Prin participarea în Liga 1 de tineret, FC Unirea Youth urmărește nu doar rezultate, ci și dezvoltarea continuă a jucătorilor, spiritul de echipă și promovarea fair-play-ului.\r\n\r\n                    Le dorim mult succes tinerilor noștri și suntem convinși că vor reprezenta cu mândrie culorile clubului! Susțineți FC Unirea Youth la fiecare meci!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2869), "FC Unirea a fost fondată în anul 2005, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. \r\n                    De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\r\n\r\n                    Echipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. \r\n                    Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016.\r\n\r\n                    În prezent, echipa este pregătită de antrenorul Petrica Florea, sub îndrumarea căruia FC Unirea continuă să-și consolideze poziția în fotbalul românesc și să inspire o nouă generație de sportivi. \r\n                    Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2869), "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. \r\n                    Echipa a luat naștere în anul 2013, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\r\n\r\n                    Încă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. \r\n                    Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\r\n\r\n                    Prin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. \r\n                    Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice.\r\n\r\n                    În prezent, echipa este pregătită de antrenorul Mihai Olaru, sub îndrumarea căruia tinerii își pot atinge potențialul și pot face pasul spre echipa de seniori.\r\n                    Hai, Unirea U21!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2871), "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. \r\n                    Echipa a fost creată în anul 2010 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\r\n\r\n                    Scopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. \r\n                    De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\r\n\r\n                    Prin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. \r\n                    Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune.\r\n\r\n                    În prezent, echipa este antrenată de Nica Cercel, un tehnician recunoscut pentru devotamentul său față de copii și pentru rezultatele obținute la nivel juvenil. \r\n                    Hai, Unirea Youth!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2872), "Echipa FC Unirea pornește la drum în noul sezon cu un lot valoros, format din jucători experimentați și tineri de perspectivă. Iată componența lotului:\r\n\r\n                    **Portari:**  \r\n                    - Daniel Rădulescu (1992)  \r\n                    - Denis Chiriac (1997)  \r\n                    - Alin Neagu (2006)  \r\n                    - Ionuț Rădulescu (2004)  \r\n\r\n                    **Fundași:**  \r\n                    - Ștefan Popescu (1996)  \r\n                    - Radu Ilie (1999)  \r\n                    - Alex Lazăr (1995)  \r\n                    - Andrei Enache (1998)  \r\n                    - Andrei Neagu (2004)  \r\n                    - Robert Vasilescu (1996)  \r\n                    - Vlad Enache (1990)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Mihai Toma (2000)  \r\n                    - Daniel Matei (1994)  \r\n                    - Sergiu Chiriac (1990)  \r\n                    - Denis Neagu (1999)  \r\n                    - George Ilie (2004)  \r\n                    - Gabriel Vasilescu (2005)  \r\n\r\n                    **Atacanți:**  \r\n                    - Daniel Stan (2003)  \r\n                    - Alex Vasilescu (1994)  \r\n                    - Denis Ilie (1991)  \r\n\r\n                    Echipa este pregătită să facă performanță și să aducă noi bucurii suporterilor!\r\n\r\n                    Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2872), "FC Unirea U21 abordează noul sezon cu o echipă tânără, plină de entuziasm și determinare. Lotul reunește atât jucători cu experiență la nivel de juniori, cât și talente aflate la început de drum, dornice să confirme la cel mai înalt nivel al fotbalului de tineret. Iată componența lotului:\r\n\r\n                    **Portari:**  \r\n                    - Denis Lazar (2004)  \r\n                    - Eduard Georgescu (2006)  \r\n                    - Alin Dumitrescu (2008)  \r\n                    - Eduard Diaconu (2005)  \r\n                    - Robert Dumitrescu (2007)  \r\n\r\n                    **Fundași:**  \r\n                    - George Diaconu (2006)  \r\n                    - Adrian Toma (2007)  \r\n                    - Alin Diaconu (2004)  \r\n                    - Alin Voicu (2005)  \r\n                    - Sergiu Radulescu (2005)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Daniel Ilie (2008)  \r\n                    - Alex Matei (2005)  \r\n                    - Robert Cojocaru (2008)  \r\n                    - Denis Cojocaru (2007)  \r\n\r\n                    **Atacanți:**  \r\n                    - Cristian Ilie (2005)  \r\n                    - Robert Ionescu (2004)  \r\n                    - Robert Radulescu (2007)  \r\n                    - Florin Matei (2005)  \r\n                    - Sergiu Neagu (2004)  \r\n                    - Eduard Popescu (2004)  \r\n\r\n                    Prin această selecție, FC Unirea U21 își propune să crească jucători valoroși, capabili să facă pasul spre fotbalul de seniori.\r\n\r\n                    Mult succes în noul sezon, U21! Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2873), "FC Unirea Youth aliniază în acest sezon un lot numeros, format din copii și adolescenți talentați, cu dorință de afirmare și mult entuziasm. Mulți dintre acești jucători reprezintă viitorul clubului și al fotbalului local. Iată componența lotului:\r\n\r\n                    **Portari:**  \r\n                    - Cristian Matei (2011)  \r\n                    - Vlad Ilie (2012)  \r\n                    - Ionuț Neagu (2009)  \r\n                    - Adrian Cojocaru (2012)  \r\n                    - Paul Vasilescu (2011)  \r\n                    - Alin Neagu (2010)  \r\n                    - Cristian Chiriac (2010)  \r\n\r\n                    **Fundași:**  \r\n                    - Gabriel Ionescu (2011)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Alin Vasilescu (2012)  \r\n                    - Andrei Ionescu (2009)  \r\n                    - Vlad Ionescu (2011)  \r\n                    - Sergiu Enache (2011)  \r\n                    - Alex Vasilescu (2010)  \r\n                    - Adrian Toma (2009)  \r\n                    - Vlad Neagu (2011)  \r\n                    - Ionuț Ilie (2010)  \r\n\r\n                    **Atacanți:**  \r\n                    - Paul Rădulescu (2011)  \r\n                    - Alin Ionescu (2009)  \r\n                    - George Neagu (2010)  \r\n                    - Ionuț Diaconu (2009)  \r\n\r\n                    Clubul investește permanent în dezvoltarea acestor copii, asigurându-le pregătire modernă și condiții optime pentru a-și atinge potențialul. Mult succes, Unirea Youth!\r\n\r\n                    Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2874), "FC Unirea Youth intră în noul sezon cu o echipă tânără și echilibrată, construită pe valori solide și pe dorința de afirmare a fiecărui copil. Jucătorii acestei generații sunt dovada investiției clubului în viitor, iar energia și ambiția lor se văd la fiecare antrenament și meci. Iată lotul complet:\r\n\r\n                    **Portari:**  \r\n                    - Adrian Cojocaru (2012)  \r\n                    - Alin Neagu (2010)  \r\n                    - Cristian Chiriac (2010)  \r\n\r\n                    **Fundași:**  \r\n                    - Cristian Matei (2011)  \r\n                    - Vlad Ilie (2012)  \r\n                    - Ionuț Neagu (2009)  \r\n                    - Gabriel Ionescu (2011)  \r\n                    - Paul Vasilescu (2011)  \r\n\r\n                    **Mijlocași:**  \r\n                    - Alin Vasilescu (2012)  \r\n                    - Andrei Ionescu (2009)  \r\n                    - Vlad Ionescu (2011)  \r\n                    - Sergiu Enache (2011)  \r\n                    - Alex Vasilescu (2010)  \r\n                    - Adrian Toma (2009)  \r\n                    - Vlad Neagu (2011)  \r\n                    - Ionuț Ilie (2010)  \r\n\r\n                    **Atacanți:**  \r\n                    - Paul Rădulescu (2011)  \r\n                    - Alin Ionescu (2009)  \r\n                    - George Neagu (2010)  \r\n                    - Ionuț Diaconu (2009)  \r\n\r\n                    Lotul este rezultatul muncii academiei și reflectă preocuparea permanentă pentru dezvoltarea tinerelor talente.  \r\n                    Succes, Unirea Youth! Hai, copii!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2875), "FC Unirea își dispută meciurile de acasă pe **Unirea Stadium**, situat în orașul Odobești.\r\n\r\n                    Stadionul dispune de o capacitate de 10 locuri și este destinat exclusiv meciurilor echipelor clubului, oferind o atmosferă caldă și apropiată de comunitatea locală. De-a lungul timpului, Unirea Stadium a găzduit numeroase momente speciale pentru suporterii alb-albaștrilor, devenind un simbol al pasiunii pentru fotbal în zonă.\r\n\r\n                    Fiecare partidă jucată pe Unirea Stadium înseamnă emoție, determinare și susținere necondiționată din partea fanilor. Clubul mulțumește tuturor celor care vin să susțină echipa și promite să facă din fiecare meci o adevărată sărbătoare a fotbalului.\r\n\r\n                    Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2876), "FC Unirea U21 joacă meciurile de acasă pe **Unirea U21 Stadium**, în orașul Odobești.\r\n\r\n                    Stadionul oferă o capacitate de 10 locuri și a devenit un loc familiar pentru generațiile de tineri fotbaliști ai clubului. Fiecare partidă disputată aici este o oportunitate pentru juniorii noștri să impresioneze și să-și construiască drumul spre performanță.\r\n\r\n                    Suporterii care vin pe Unirea U21 Stadium creează o atmosferă caldă și încurajatoare, ajutând echipa să se simtă mereu susținută, indiferent de rezultat. Stadionul reprezintă un punct de pornire spre cariere de succes pentru mulți jucători crescuți la FC Unirea.\r\n\r\n                    Mult succes în noul sezon, Unirea U21!\r\n                    Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2877), "FC Unirea Youth își dispută meciurile de acasă pe **Unirea Youth Stadium**, situat în Odobești.\r\n\r\n                    Acest stadion, cu o capacitate de 10 locuri, este locul unde copiii și adolescenții clubului fac primii pași în fotbalul organizat. Pentru mulți dintre ei, Unirea Youth Stadium reprezintă locul unde pasiunea pentru fotbal se transformă în visuri, prietenii și primele reușite sportive.\r\n\r\n                    Fiecare meci disputat aici este o oportunitate de a învăța, de a se bucura de fotbal și de a construi viitorul clubului. Atmosfera este mereu caldă, iar suporterii prezenți îi încurajează pe tinerii jucători la fiecare pas.\r\n\r\n                    Hai, Unirea Youth!" });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Text" },
                values: new object[] { new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2877), "La fiecare meci disputat pe **Unirea Stadium** din Odobești, suporterii au la dispoziție o gamă variată de locuri, atât pentru cei care preferă confortul maxim, cât și pentru cei care vor să simtă pulsul tribunei alături de ceilalți fani.\r\n\r\n                    **Locuri disponibile:**  \r\n                    - VIP: A1, A2 (preț: 150 lei/bilet)  \r\n                    - Standard: B1, B2, C1, C2, D1, D2, E1, E2 (preț: 50 lei/bilet)  \r\n\r\n                    Indiferent de tipul biletului ales, fiecare suporter contribuie la atmosfera specială de pe stadion și la susținerea echipei. Vă așteptăm la fiecare meci să vă bucurați de fotbal și să susțineți FC Unirea din tribunele noastre!\r\n\r\n                    Hai, Unirea!" });

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "FC Unirea a fost fondată în anul 2005, având ca scop promovarea valorilor sportive și dezvoltarea fotbalului la nivel local. De-a lungul anilor, clubul a reușit să atragă numeroși tineri talentați din regiune, devenind rapid un punct de referință pentru fotbalul comunitar.\r\n\r\nEchipa a debutat în ligile inferioare, dar datorită muncii susținute și implicării staff-ului, FC Unirea a obținut promovări succesive, ajungând să participe în competiții naționale și ulterior europene. Performanțele notabile includ câștigarea campionatului regional în 2012 și participarea constantă în primele eșaloane ale fotbalului românesc începând cu sezonul 2015-2016. ");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 11,
                column: "Description",
                value: "FC Unirea U21 a fost înființată ca parte a strategiei de dezvoltare a clubului FC Unirea, având ca principal obiectiv creșterea și promovarea tinerilor jucători către echipa de seniori. Echipa a luat naștere în anul 2013, din dorința de a oferi o rampă de lansare pentru fotbaliștii talentați cu vârste sub 21 de ani.\r\n\r\nÎncă de la început, FC Unirea U21 a participat în competițiile naționale de juniori și tineret, obținând rezultate remarcabile și construind o reputație solidă pentru profesionalism și implicare. Mulți dintre jucătorii promovați din cadrul acestei echipe au ajuns ulterior să evolueze cu succes la nivel de seniori, contribuind la performanțele clubului-mamă.\r\n\r\nPrin accentul pus pe formare, disciplină și joc de echipă, FC Unirea U21 a devenit un pilon esențial în structura clubului, reprezentând legătura directă dintre academia de juniori și prima echipă. Clubul investește constant în infrastructură, staff și programe de pregătire pentru a asigura continuitatea valorilor și performanțelor fotbalistice. ");

            migrationBuilder.UpdateData(
                table: "Teams",
                keyColumn: "Id",
                keyValue: 21,
                column: "Description",
                value: "FC Unirea Youth reprezintă segmentul de juniori al clubului FC Unirea, fiind dedicat dezvoltării copiilor și adolescenților pasionați de fotbal. Echipa a fost creată în anul 2010 ca răspuns la dorința clubului de a construi o academie puternică și de a forma jucători încă de la cele mai fragede vârste.\r\n\r\nScopul principal al FC Unirea Youth este identificarea și formarea tinerelor talente, oferindu-le acestora condiții moderne de pregătire, antrenori calificați și participarea la competiții locale și regionale. De-a lungul anilor, această structură a devenit un adevărat incubator de jucători pentru club, numeroși fotbaliști ajungând ulterior să evolueze pentru FC Unirea U21 sau chiar la nivel de seniori.\r\n\r\nPrin activitatea sa, FC Unirea Youth promovează nu doar performanța sportivă, ci și valorile educației, fair-play-ului și respectului față de adversar. Clubul continuă să investească în infrastructură și în programe de formare, consolidându-și statutul de centru de excelență pentru tinerii fotbaliști din regiune. ");

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 4,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 5,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 6,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2189));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 7,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 8,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 9,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 10,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 11,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 12,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 13,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 14,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 15,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 16,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 17,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 18,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 19,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 20,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 21,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 22,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2203));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 23,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 24,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 25,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 26,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 27,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 28,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 29,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 30,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 31,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 32,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2211));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 33,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2212));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 34,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 35,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 36,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2215));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 37,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 38,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2216));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 39,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2217));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 40,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2218));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 41,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2219));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 42,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 43,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2220));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 44,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2221));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 45,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2222));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 46,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2223));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 47,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 48,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2224));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 49,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2225));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 50,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2226));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 51,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2227));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 52,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 53,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2228));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 54,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2229));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 55,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2230));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 56,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 57,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 58,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2232));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 59,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2233));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 60,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2234));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 61,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 62,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2235));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 63,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2236));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 64,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2237));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 65,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2238));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 66,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2270));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 67,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 68,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 69,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2272));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 70,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2273));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 71,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2274));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 72,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 73,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2275));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 74,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2276));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 75,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2277));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 76,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2278));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 77,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 78,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2279));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 79,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2280));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 80,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2281));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 81,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 82,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 83,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2283));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 84,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 85,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2285));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 86,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2286));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 87,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 88,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2287));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 89,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2288));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 90,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2289));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 91,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 92,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2290));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 93,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 94,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2292));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 95,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2293));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 96,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 97,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 98,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2295));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 99,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2296));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 100,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 101,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 102,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2298));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 103,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 104,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 105,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2301));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 106,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 107,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 108,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 109,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2304));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 110,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 111,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 112,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 113,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2307));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 114,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 115,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2309));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 116,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 117,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2310));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 118,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2311));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 119,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2312));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 120,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 121,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2313));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 122,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2314));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 123,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2315));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 124,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2316));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 125,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 126,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2317));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 127,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 128,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2319));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 129,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2320));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 130,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2322));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 131,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 132,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 133,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 134,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2325));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 135,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 136,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 137,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2327));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 138,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2359));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 139,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 140,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2361));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 141,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2362));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 142,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2363));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 143,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2364));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 144,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 145,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2365));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 146,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2366));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 147,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2367));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 148,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2368));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 149,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2369));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 150,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 151,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2370));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 152,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 153,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2372));

            migrationBuilder.UpdateData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: 154,
                column: "DateReservation",
                value: new DateTime(2025, 6, 1, 0, 15, 6, 490, DateTimeKind.Utc).AddTicks(2373));
        }
    }
}
