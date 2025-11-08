# Back-end

Back-end for **Nerf-Prince SmartHack app**.

---

## INSTRUCTIUNI

### Pentru baza de date

```bash
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=mydb;Username=postgres;Password=MyPass123!"
dotnet add package MongoDB.Driver


