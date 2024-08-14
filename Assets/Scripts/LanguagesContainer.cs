using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Languages
{
    English = 0,
    Russian = 1,
    Brazilian = 2
}

public enum TextKeys
{
    Hello,
    EnterText,
    Back,
    Acquainted,
    Name,
    Age,
    SpecifyAge,
    YourWeight,
    Weight,
    YourGender,
    Male,
    Female,
    Gender,
    Next,
    FactName,
    Fact,
    LastRecipes,
    RecommendedRecipes,
    RecommendedExercises,
    Home,
    Recipes,
    Exercises,
    RecipesFor,
    ExercisesFor,
    Profile
}

public class LanguagesContainer : MonoBehaviour
{
    private static Languages gameLanguage = Languages.Russian;
    public static Languages GameLanguage => gameLanguage;
    public Dictionary<Languages, Dictionary<TextKeys, string>> WordsDictionary { get; private set; }
    public Dictionary<Languages, Dictionary<FiltersTypes, string>> TagsDictionary { get; private set; }
    public UnityEvent LanguageChanged;

    public static LanguagesContainer Instance { get; private set; }

    // Singleton only because I have no time, thanks for understanding 

    private void Awake()
    {
        Instance ??= this;
        FillWordsDictionary();
        ChangeLanguage((Languages)PlayerPrefs.GetInt(PlayerPrefsKeys.Language, 1));
        // To be rewritten using progress and json saves
    }

    public void ChangeLanguage(Languages language)
    {
        gameLanguage = language;
        PlayerPrefs.SetInt(PlayerPrefsKeys.Language, (int)gameLanguage);
        // And that's like 28th says
        LanguageChanged?.Invoke();
    }

    public void SetToRussian() =>
        ChangeLanguage(Languages.Russian);

    public void SetToEnglish() =>
        ChangeLanguage(Languages.English);

    public void SetToBrazil() =>
        ChangeLanguage(Languages.Brazilian);

    private void FillWordsDictionary()
    {
        WordsDictionary = new Dictionary<Languages, Dictionary<TextKeys, string>>()
        {
            [Languages.Russian] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.Hello] = "Привет!",
                [TextKeys.EnterText] = "Это приложение создано для людей, ведущих активный образ жизни и заботящихся о своем здоровье. Приложение предоставляет доступ к коллекции рецептов с подсчетом калорий, временем приготовления и информацией о пользе для здоровья. Оно также включает базу данных упражнений, организованных по частям тела, с информацией о том, когда их делать, и рекомендациями.",
                [TextKeys.Back] = "Назад",
                [TextKeys.Acquainted] = "Давайте знакомиться",
                [TextKeys.Name] = "Имя",
                [TextKeys.Age] = "Возраст",
                [TextKeys.SpecifyAge] = "Укажите возраст",
                [TextKeys.YourWeight] = "Ваш вес",
                [TextKeys.Weight] = "Вес",
                [TextKeys.YourGender] = "Укажите пол",
                [TextKeys.Male] = "Мужской",
                [TextKeys.Female] = "Женский",
                [TextKeys.Gender] = "Пол",
                [TextKeys.Next] = "Дальше",
                [TextKeys.FactName] = "Рыба заботится о сердце",
                [TextKeys.Fact] = "Риск сердечных заболеваний значительно ниже у женщин, которые регулярно употребляют рыбу, богатую омега-3 жирными кислотами. Об этом свидетельствуют результаты недавнего датского исследования. В исследовании приняли участие женщины в возрасте от 15 до 49 лет. Оказалось, что те представительницы слабого пола, которые употребляют рыбу редко или вообще не употребляют ее, в 2 раза чаще страдают сердечно-сосудистыми заболеваниями, чем те, кто регулярно употребляет рыбу. Большинство опрошенных женщин, регулярно включавших рыбу в свой рацион, заявили, что отдают предпочтение лососю, треске, сельди и скумбрии, которые богаты омега-3 жирными кислотами. Чтобы ощутить положительный эффект от употребления рыбы, ее следует включать в меню не реже двух раз в неделю.",
                [TextKeys.LastRecipes] = "Последние рецепты",
                [TextKeys.RecommendedRecipes] = "Рекомендуемые рецепты",
                [TextKeys.RecommendedExercises] = "Рекомендуемые упражнения",
                [TextKeys.Home] = "Главная",
                [TextKeys.Recipes] = "Рецепты",
                [TextKeys.Exercises] = "Упражнения",
                [TextKeys.Profile] = "Профиль",
                [TextKeys.RecipesFor] = "Рецепты на",
                [TextKeys.ExercisesFor] = "Упражнения для"
            },

            [Languages.English] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.Hello] = "Hello!",
                [TextKeys.EnterText] = "This is an app designed for people with an active lifestyle and those who care about their health. The app provides access to a collection of recipes with calorie counts, cooking times and information on health benefits. It also includes a database of exercises organised by body part, with information on when to do them and recommendations.",
                [TextKeys.Back] = "Back",
                [TextKeys.Acquainted] = "Let's get acquainted",
                [TextKeys.Name] = "Name",
                [TextKeys.Age] = "Age",
                [TextKeys.SpecifyAge] = "Specify age",
                [TextKeys.YourWeight] = "Your weight",
                [TextKeys.Weight] = "Weight",
                [TextKeys.YourGender] = "Specify gender",
                [TextKeys.Male] = "Male",
                [TextKeys.Female] = "Female",
                [TextKeys.Gender] = "Gender",
                [TextKeys.Next] = "Next",
                [TextKeys.FactName] = "Fish takes care of the heart",
                [TextKeys.Fact] = "The risk of heart problems is much lower in women who regularly eat fish rich in omega-3 fatty acids. This is according to the results of a recent Danish study. The study involved women aged 15 to 49 years. It turned out that those representatives of the weaker sex, who use fish rarely or never eat it, are 2 times more likely to suffer from cardiovascular disease than those who eat fish regularly. Most of the women surveyed who regularly included fish in their diet said they favoured salmon, cod, herring and mackerel, which are rich in omega-3 fatty acids. To feel the positive effects of fish consumption, it should be included in the menu at least twice a week.",
                [TextKeys.LastRecipes] = "Last recipes",
                [TextKeys.RecommendedRecipes] = "Recommended recipes",
                [TextKeys.RecommendedExercises] = "Recommended exercises",
                [TextKeys.Home] = "Home",
                [TextKeys.Recipes] = "Recipes",
                [TextKeys.Exercises] = "Exercises",
                [TextKeys.Profile] = "Profile",
                [TextKeys.RecipesFor] = "Recipes for",
                [TextKeys.ExercisesFor] = "Exercises for"
            },

            [Languages.Brazilian] = new Dictionary<TextKeys, string>()
            {
                [TextKeys.Hello] = "Hola",
                [TextKeys.EnterText] = "Se trata de una aplicación diseñada para personas con un estilo de vida activo y que se preocupan por su salud. La aplicación proporciona acceso a una colección de recetas con recuento de calorías, tiempos de cocción e información sobre los beneficios para la salud. También incluye una base de datos de ejercicios organizados por parte del cuerpo, con información sobre cuándo realizarlos y recomendaciones.",
                [TextKeys.Back] = "Atrás",
                [TextKeys.Acquainted] = "Vamos a conocernos",
                [TextKeys.Name] = "Nombre",
                [TextKeys.Age] = "Edad",
                [TextKeys.SpecifyAge] = "Especificar edad",
                [TextKeys.YourWeight] = "Tu peso",
                [TextKeys.Weight] = "Peso",
                [TextKeys.YourGender] = "Tu género",
                [TextKeys.Male] = "Masculino",
                [TextKeys.Female] = "Femenina",
                [TextKeys.Gender] = "Género",
                [TextKeys.Next] = "Próximo",
                [TextKeys.FactName] = "El pescado cuida el corazón",
                [TextKeys.Fact] = "El riesgo de sufrir problemas cardíacos es mucho menor en las mujeres que consumen regularmente pescado rico en ácidos grasos omega-3, según los resultados de un reciente estudio danés en el que participaron mujeres de entre 15 y 49 años. Resultó que las representantes del sexo débil que consumen pescado rara vez o nunca lo comen tienen el doble de probabilidades de sufrir enfermedades cardiovasculares que las que comen pescado regularmente. La mayoría de las mujeres encuestadas que incluían pescado regularmente en su dieta dijeron que preferían el salmón, el bacalao, el arenque y la caballa, que son ricos en ácidos grasos omega-3. Para sentir los efectos positivos del consumo de pescado, debería incluirse en el menú al menos dos veces por semana.",
                [TextKeys.LastRecipes] = "Últimas recetas",
                [TextKeys.RecommendedRecipes] = "Recetas recomendadas",
                [TextKeys.RecommendedExercises] = "Ejercicios recomendados",
                [TextKeys.Home] = "Hogar",
                [TextKeys.Recipes] = "Receta",
                [TextKeys.Exercises] = "Ceremonias",
                [TextKeys.Profile] = "Perfil",
                [TextKeys.RecipesFor] = "Recetas para",
                [TextKeys.ExercisesFor] = "Ejercicios para"
            }
        };

        TagsDictionary = new()
        {
            [Languages.English] = new Dictionary<FiltersTypes, string>()
            {
                [FiltersTypes.Breakfast] = "Breakfast",
                [FiltersTypes.Lunch] = "Lunch",
                [FiltersTypes.Dinner] = "Dinner",
                [FiltersTypes.Dessert] = "Dessert",
                [FiltersTypes.AllForRecipes] = "All",
                [FiltersTypes.Head] = "Head",
                [FiltersTypes.Foots] = "Foots",
                [FiltersTypes.Body] = "Body",
                [FiltersTypes.Hands] = "Hands",
                [FiltersTypes.Neck] = "Neck",
                [FiltersTypes.Back] = "Back",
                [FiltersTypes.Belly] = "Belly",
                [FiltersTypes.AllForExercises] = "All"
            },
            [Languages.Russian] = new Dictionary<FiltersTypes, string>()
            {
                [FiltersTypes.Breakfast] = "Завтрак",
                [FiltersTypes.Lunch] = "Обед",
                [FiltersTypes.Dinner] = "Ужин",
                [FiltersTypes.Dessert] = "Десерт",
                [FiltersTypes.AllForRecipes] = "Всё",
                [FiltersTypes.Head] = "Голова",
                [FiltersTypes.Foots] = "Ноги",
                [FiltersTypes.Body] = "Корпус",
                [FiltersTypes.Hands] = "Руки",
                [FiltersTypes.Neck] = "Шея",
                [FiltersTypes.Back] = "Спина",
                [FiltersTypes.Belly] = "Живот",
                [FiltersTypes.AllForExercises] = "Всё"
            },
            [Languages.Brazilian] = new Dictionary<FiltersTypes, string>()
            {
                [FiltersTypes.Breakfast] = "Desayuno",
                [FiltersTypes.Lunch] = "Almuerzo",
                [FiltersTypes.Dinner] = "Cena",
                [FiltersTypes.Dessert] = "Postre",
                [FiltersTypes.AllForRecipes] = "Todo",
                [FiltersTypes.Head] = "Cabeza",
                [FiltersTypes.Foots] = "Pie",
                [FiltersTypes.Body] = "Cuerpo",
                [FiltersTypes.Hands] = "Manos",
                [FiltersTypes.Neck] = "Cuello",
                [FiltersTypes.Back] = "Atrás",
                [FiltersTypes.Belly] = "Barriga",
                [FiltersTypes.AllForExercises] = "Todo"
            }
        };
    }
}



