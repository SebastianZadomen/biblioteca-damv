# Sistema de gestió de biblioteca - Projecte DAM
## PREGUNTAS REFLEXIVAS
### Pregunta 1: Identificació de problemes

Després d'executar SonarQube, observa l'informe generat:
Quins són els 3 problemes més crítics detectats?

Per què creus que SonarQube els classifica així?

Quin impacte podrien tenir aquests problemes en producció?

- La clase Program no tiene modificador de acceso
- Faltan modificadores de acceso como public o private en varios metodos.
- Conversiones sin validar.
SonarQube los clasifica así porque afectan a la mantenibilidad y pueden causar errores en tiempo de ejecución.
En producción podrían generar crashes o datos inválidos .
---
### Pregunta 2: Correcció de codi
Tria un dels problemes detectats i proposa una solució:

Com modificaries el codi per solucionar-lo?

Quines bones pràctiques apliques?

Com pots verificar que la solució és correcta?

Posible entrada erronea o null.

linea 27  string opcio = Console.ReadLine();

En este caso al ser una opcion numerica podemos hacer que el tipo sea int y hacer la conversion , para evitar errores usariamos el try-catch el cual captura y los muestra ademas de usar un do-while para cada vez que lo escriba mal vuelva a pedir el numero 

---
### Pregunta 3: Integració contínua
Quina diferència veus entre executar SonarQube manualment i integrar-lo en un pipeline CI/CD?

Quins avantatges aporta l'automatització?

En quin moment del desenvolupament és més útil executar aquestes anàlisis?

- La forma manual depende mucho del programador y suele ser mas tedioso a la hora de ejecutar ademas de que puede dar problemas si no tienes conocimientos .
- CI/CD se ejecuta automaticamente en cada commit lo cual hace el trabajo mas comodo y seguro .
 El momento ideal seria despues de cada pull request o un merge asi tenemos un feedback de lo que pasa en nuestro codigo para mejorar 

---
### Pregunta 4: Comparació d'eines
Has treballat amb SonarQube, Jenkins i GitHub Actions:
Quina eina t'ha semblat més fàcil de configurar? Per què?

Quins avantatges i desavantatges veus en cadascuna?

Quina utilitzaries en un projecte real i per què?

Me resulta mas facil GitHub Actions ya que no requiere una instalacion como tal y es automatico.
SonarQube es muy completo pero necesita servidor  .
Jenkins tambien es completo pero tiene un poco mas de complejidad.
Usaría GitHub Actions + SonarCloud por simplicidad.

---
### Pregunta 5: Mètriques de qualitat
A l'informe de SonarQube, observa les mètriques:
Què significa la "complexitat ciclomàtica"?

Per què és important la cobertura de tests?

Quin percentatge de deute tècnic (technical debt) considera acceptable?

La complejidad ciclomática mide cuántos caminos lógicos tiene un método (if, loops, etc.).
La cobertura de tests es importante porque garantiza que el código está probado y reduce errores.

Un porcentaje razonable de technical debt suele ser menos del 5%.


---
### Pregunta 6: Workflow en equip
Imagina que treballes en un equip de 5 desenvolupadors:
Com utilitzaries aquestes eines per assegurar la qualitat del codi?

Quin workflow proposaries (branching, PR, CI/CD)?

Què faries si algú fa un commit que falla l'anàlisi?

Usaría CI/CD + SonarQube para revisar cada commit.
Workflow: cada desarrollador crea una rama, hace un PR, se ejecuta el análisis y si todo está bien se hace el merge.
Si algo falla, no permitiría hacer el merge hasta corregirlo.

## SonarQube
### Antes
![antes](/resources/antes.png)
### Despues
![despues](/resources/despues.png)
