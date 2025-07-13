# Database Schema – ConferenceManager

This document describes the structure of the database tables used in the ConferenceManager system.

---

## AppParticipants

**Description:** Stores data about participants registered for the conference.

| Column       | Data Type         | Constraints                  | Description                      |
|--------------|-------------------|------------------------------|----------------------------------|
| `Id`         | `uniqueidentifier`| Primary Key, Required        | Unique ID of the participant     |
| `FirstName`  | `nvarchar(MAX)`   | Required                     | First name of the participant    |
| `LastName`   | `nvarchar(MAX)`   | Required                     | Last name of the participant     |
| `Email`      | `nvarchar(450)`   | Required, Unique             | Email address                    |
| `Phone`      | `nvarchar(MAX)`   | Required                     | Phone number                     |
| `TicketType` | `int`             | Required                     | Type of ticket (see enum below)  |

**Primary Key:**
- `PK_AppParticipants` on `Id`

**Unique Index:**
- `IX_AppParticipants_Email` on `Email`

---

## TicketType (Enum)

**Description:** Defines the available ticket types in the system.

| Value | Name     | Description         |
|-------|----------|---------------------|
| 0     | Discount | Discounted ticket   |
| 1     | Normal   | Standard ticket     |
| 2     | Vip      | VIP ticket          |

This enum is mapped to the `TicketType` column as an integer.

---

## Notes

- The table was generated via EF Core migrations based on the `Participant` entity.
- The email address must be unique – enforced via a unique index.

---

## Example Entity Class

```csharp
public class Participant : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public TicketType TicketType { get; set; }
}
