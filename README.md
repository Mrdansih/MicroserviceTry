# .NET Microservice Setup

Dette projekt består af **2 microservices** og en **API gateway**.  
README’en fokuserer på hvordan du anvender systemet gennem **Postman**.

---

## Struktur
| Komponent            | Beskrivelse                 | Port |
|----------------------|-----------------------------|------|
| ProductMicroservice  | Håndtere produkt funktioner | `5002` |
| AuthMicroservice     | Håndtere bruger funktioner  | `5001` |
| Gateway (YARP)       | Routing mellem services     | `5000` |

## Postman
