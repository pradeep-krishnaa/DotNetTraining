# ISsueTracker phase 4 - Onion Architecture and Solid principles

## 📁 Project Structure

**IssueTrcker**

- **Core**  
  - Entities - `Bug.cs`  
  - Interfaces - `IBugRepository`  

- **Application**  
  - Services - `BugService`  

- **Infrastructure**  
  - Repositories - `BugRepository`  

- **ConsoleApp**  
  - `Program.cs`  

---

## 🧱 Bug.cs

- `id`  
- `title`  
- `description`  
- `status`  

---

## 🔌 IBugRepository

```
List<Bug> GetAllBugs();  
Bug GetBugById(int id);  
void AddBug(Bug bug);  
void UpdateBug(Bug bug);  
void DeleteBug(int id);  
```

---

## 🏗️ BugRepository

- Implements `IBugRepository`
- Created readonly list for bugs
- Implemented all methods in `IBugRepository`

---

## 🧠 BugService

- Has private readonly `IBugRepository _bugRepository`
- Constructor:

```
public BugService(IBugRepository bugRepository)
{
    _bugRepository = bugRepository;
}
```

- A method to create bugs - adds bugs using `_bugRepository`
- A method to get all bugs

---

## 🔗 Project References

- `Infrastructure` → added project reference to `Core`  
- `Application` → added project reference to `Core`  
- `ConsoleApp` → added project reference to both `Infrastructure` and `Application`  

✅ Set `ConsoleApp` as startup project  

---

## 🧾 Git Commands

```bash
git add IssueTrackerPhase4  
git commit -m "msg"  
git push origin main  
```
