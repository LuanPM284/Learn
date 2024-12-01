# Personal Notes
## Learning MVVM
These are my personal notes on learning MVVM, the sources used are:
- openclassrooms - [Développez votre première application Android](https://openclassrooms.com/en/courses/8150246-developpez-votre-premiere-application-android/8256880-structurez-l-application-avec-l-architecture-mvvm)
- learn.microsoft - [Model-View-ViewModel (MVVM)](https://learn.microsoft.com/en-us/dotnet/architecture/maui/mvvm)
- Youtube - [What is the MVVM pattern, What benefits does MVVM have?](https://www.youtube.com/watch?v=AXpTeiWtbC8&t=1s)

## openclassrooms (https://openclassrooms.com/en/)
### Structurez l’application avec l’architecture MVVM

Architecture logicielle - patron/pattern d’architecture.

Eviter du code spaghetti, du code sans interconnexions. Difficile à comprendre et à maintenir.

![Exemple](/MVVM/Code_Spaghetti_Exemple.jpg)


Différents modèdeles existent comme MVC(Model, View, Control), MVI, MVP ou encore MVVM (préconisé par Google).

### L’architecture MVVM

MVVM: Model - View - ViewModel
3 couches:
    - Model: Couche de Données
    - View: Couche Vue, interaction avec utilisateur
    - ViewModel: Couche intérmediaire

![Exemple 1](/MVVM/MVVM_Exemple_1.jpg)

"MVVM isole donc dans le code deux parties distinctes. D’un côté les éléments correspondant à la vue, de l’autre côté les éléments représentant les données de l’application. On appelle ces différentes parties des **couches** d’architecture. "

### Le pattern ViewModel

"Le pattern **ViewModel** a pour rôle de préparer les données dont un écran de l’application aura besoin (la couche Vue). "

1. "Exposer à la Vue les données finales que l’interface doit représenter ; on appelle ces données des **états**."

2. "Mettre à disposition de la Vue des fonctions correspondant à des **événements** chargés de modifier les données suite aux  interactions ayant lieu sur l’interface."

"Un **état** désigne **toute valeur susceptible de changer au fil du temps.**"

"Un **événement** désigne **toute modification pouvant avoir lieu dans une application et ayant un impact sur l’état de l’interface** : une interaction de l’utilisateur comme un clic sur un bouton, une saisie, un scroll, mais également toute mise à jour d’un paramètre intrinsèque à l’application ayant un impact sur celle-ci, par exemple un décompte qui se termine au sein d’une application de type “Minuteur”." => Une classe

![Exemple 2](/MVVM/MVVM_Exemple_2.jpg)

"On applique ainsi un design pattern appelé flux de données unidirectionnel (ou Unidirectional Data Flow – UDF). " 

Unidirectional: événement => état

"Lorsque nous mettons en place la couche Données d’une application, il est d’usage de placer les fichiers relatifs à cette couche au même endroit, par exemple dans un package nommé `data` ."

Ici nous avons un exemple d'une classe crée qui permettra de représenter l'object principal. La partie *View*.

```java
// Data/Questions.java
// A Class
public class Question {
    //Fieds
    private final String question;
    private final List<String> choiceList;
    private final Integer answerIndex;
        // A constructor
        public Question(String question, List<String> choiceList, int answerIndex) {
        this.question = question;
        this.choiceList = choiceList;
        this.answerIndex = answerIndex;
    }
    // Methods
    public String getQuestion() {
        return question;
    }

    public List<String> getChoiceList() {
        return choiceList;
    }

    public Integer getAnswerIndex() {
        return answerIndex;
    }
}
```

Pour la partie qui concerne les données on dois adapter à la  façon dont ceux sont stockés. Ici c'est un exemple locale


```java
// Data/QuestionsBank.java
public class QuestionBank {
    public List<Question> getQuestions() {
       return Arrays.asList(
                new Question(
                        "Who is the creator of Android?",
                        Arrays.asList(
                                "Andy Rubin",
                                "Steve Wozniak",
                                "Jake Wharton",
                                "Paul Smith"
                        ),
                        0
                ),
                new Question(
                        "When did the first man land on the moon?",
                        Arrays.asList(
                                "1958",
                                "1962",
                                "1967",
                                "1969"
                        ),
                        3
                ),
                new Question(
                        "What is the house number of The Simpsons?",
                        Arrays.asList(
                                "42",
                                "101",
                                "666",
                                "742"
                        ),
                        3
                ),
                new Question(
                        "Who painteddid the Mona Lisa paint?",
                        Arrays.asList(
                                "Michelangelo",
                                "Leonardo Da Vinci",
                                "Raphael",
                                "Caravaggio"
                        ),
                        1
                ),
                new Question(
                        "What is the country top-level domain of Belgium?",
                        Arrays.asList(
                                ".bg",
                                ".bm",
                                ".bl",
                                ".be"
                        ),
                        3
                )
        );
   }
    private static QuestionBank instance;
    public static QuestionBank getInstance() {
        if (instance == null) {
         instance = new QuestionBank();
        }
        return instance;
    }
}
```

![Exemple Model](/MVVM/MVVM_Exemple_Model.jpg)

"Pour exposer les données dont l’application a besoin, nous allons utiliser le pattern **Repository** (oui, je sais, encore un pattern…). Voyons à quoi il va servir."

#### Le pattern Repository

"Ce pattern consiste à utiliser une classe intermédiaire pour servir de **médiateur** entre le ViewModel et les différentes sources de données."

Ce médiateur permet d'organizer les données de différentes sources. Permettant l'intégration dans le Cloud via une API, ou rester en local.

![Exemple Pattern Repository](/MVVM/MVVM_Exemple_pattern_repository.jpg)

"Un Repository permet donc de :
- centraliser l’accès aux données ;
- gérer à un endroit unique la logique permettant de définir quelle source de données utiliser."

"Il convient de créer **un Repository pour chaque type de donnée** que manipule une application."

```java
// Data/QuestionsRepository.java
public class QuestionRepository {
    private final QuestionBank questionBank;

    public QuestionRepository(QuestionBank questionBank) {
        this.questionBank = questionBank;
    }

    public List<Question> getQuestions() {
        return questionBank.getQuestions();
    }
}
```

#### Pattern ViewModel

"Pour rappel, le pattern ViewModel a deux objectifs : 
- Exposer des données, ou **états**, représentant les informations dont l’interface a besoin.
- Fournir des fonctions correspondant aux **événements** qui ont lieu sur l’interface et qui nécessitent la modification des données."

Ici dans notre exemple nous avons *ui* user interface, pour la partie View. Comportent:
- `QuizFragment`;
- `WelcomeFragment`  .

La partie ViewModel aura comme nom *QuizViewModel*