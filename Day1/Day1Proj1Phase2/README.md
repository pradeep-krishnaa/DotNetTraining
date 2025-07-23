# Day 1 - Project 1 - Phase 2

## Ticket Management System - Enhanced

This phase extends the basic Ticket Management System by enhancing the `Ticket` class with new properties and functionality. The system continues to manage users and tickets efficiently using object-oriented principles.

---

## Updates in Phase 2

### Enhancements to `Ticket` Class

- **New Properties Added:**
  - `priority` — The urgency level of the ticket (e.g., Low, Medium, High)
  - `CreatedOn` — Timestamp indicating when the ticket was created

- **New Method Added:**
  - `Reassignticket(user)` — Reassigns the ticket to another user

### Additional Implementation

- Created **multiple objects** of `User` and `Ticket` to simulate real-world use cases.
- Demonstrated reassignment functionality by updating the `createdBy` field using the new method.

---

## Output Screenshots

<img width="893" height="419" alt="image" src="https://github.com/user-attachments/assets/6fea7259-2428-4662-8a1f-c55e3eed7f8f" />


## Git Commands Used

```bash
git init
git remote add origin <repository-url>
git add .
git commit -m "feat: enhanced ticket class with priority and reassignment"
git branch
git branch -M main
git push origin main
