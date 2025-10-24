# .NET Microservice Setup

Dette projekt består af **2 microservices** og en **API gateway**.  
README’en fokuserer på hvordan du anvender systemet gennem **Postman**.

---

## Struktur
| Komponent            | Beskrivelse                 | Port	  |
|----------------------|-----------------------------|--------|
| ProductMicroservice  | Håndtere produkt funktioner | `5002` |
| AuthMicroservice     | Håndtere bruger funktioner  | `5001` |
| Gateway (YARP)       | Routing mellem services     | `5000` |

## Postman

For at bruge dette system skal der bruges **Postman** da der ikke
er noget UI tilknyttet

# Login/Register

For at lave en user skal man bruge dette i Postman:
´http://localhost:8080/api/user/register´

Metoden skal sættes som post og i body skal man indtaste dette:
´´´
{
    "username":"User1",
    "password":"User1"
}
´´´

Da metoden i api'en er markeret som FromBody

Den samme fremgangs måde bliver også brgut til login kaldet er bare ændret til:
´http://localhost:8080/api/user/login´
