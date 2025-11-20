using ObjectOrientedPractics.Model;
using ObjectOrientedPractics.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectOrientedPractics.Services
{
    public static class DataTools
    {
        /// <summary>
        /// Делегат для сортировки списка товаров.
        /// </summary>
        /// <param name="items">Список товаров для сортировки.</param>
        /// <returns>Новый упорядоченный список товаров.</returns>
        public delegate List<Item> ItemsSorter(List<Item> items);

        /// <summary>
        /// Универсальный метод фильтрации товаров с использованием Func<>.
        /// </summary>
        /// <param name="items">Список товаров для фильтрации.</param>
        /// <param name="filter">Func-фильтр для применения к товарам.</param>
        /// <returns>Новый список отфильтрованных товаров.</returns>
        public static List<Item> FilterItems(List<Item> items, Func<Item, bool> filter)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            var filteredItems = new List<Item>();

            foreach (var item in items)
            {
                if (filter(item))
                {
                    filteredItems.Add(item);
                }
            }

            return filteredItems;
        }

        /// <summary>
        /// Универсальный метод сортировки товаров по внешнему делегату.
        /// </summary>
        /// <param name="items">Список товаров для сортировки.</param>
        /// <param name="sorter">Делегат сортировки.</param>
        /// <returns>Новый упорядоченный список товаров.</returns>
        public static List<Item> SortItems(List<Item> items, ItemsSorter sorter)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            if (sorter == null)
                throw new ArgumentNullException(nameof(sorter));

            return sorter(items);
        }

        /// <summary>
        /// Сортировка товаров по имени (алфавитный порядок).
        /// </summary>
        public static List<Item> SortByName(List<Item> items)
        {
            var sortedList = new List<Item>(items);
            sortedList.Sort((item1, item2) => string.Compare(item1.Name, item2.Name, StringComparison.OrdinalIgnoreCase));
            return sortedList;
        }

        /// <summary>
        /// Сортировка товаров по возрастанию стоимости.
        /// </summary>
        public static List<Item> SortByCostAscending(List<Item> items)
        {
            var sortedList = new List<Item>(items);
            sortedList.Sort((item1, item2) => item1.Cost.CompareTo(item2.Cost));
            return sortedList;
        }

        /// <summary>
        /// Сортировка товаров по убыванию стоимости.
        /// </summary>
        public static List<Item> SortByCostDescending(List<Item> items)
        {
            var sortedList = new List<Item>(items);
            sortedList.Sort((item1, item2) => item2.Cost.CompareTo(item1.Cost));
            return sortedList;
        }

        /// <summary>
        /// Сортировка товаров по категории, затем по имени.
        /// </summary>
        public static List<Item> SortByCategoryThenByName(List<Item> items)
        {
            var sortedList = new List<Item>(items);
            sortedList.Sort((item1, item2) =>
            {
                int categoryComparison = item1.Category.CompareTo(item2.Category);
                return categoryComparison != 0 ? categoryComparison : string.Compare(item1.Name, item2.Name, StringComparison.OrdinalIgnoreCase);
            });
            return sortedList;
        }

        // === БИБЛИОТЕКА СТАНДАРТНЫХ ФИЛЬТРОВ ===

        /// <summary>
        /// Возвращает фильтр для стоимости выше указанного значения.
        /// </summary>
        public static Func<Item, bool> CreateCostFilter(double minCost)
        {
            return item => item.Cost > minCost;
        }

        /// <summary>
        /// Возвращает фильтр для стоимости в указанном диапазоне.
        /// </summary>
        public static Func<Item, bool> CreateCostRangeFilter(double minCost, double maxCost)
        {
            return item => item.Cost >= minCost && item.Cost <= maxCost;
        }

        /// <summary>
        /// Возвращает фильтр для указанной категории.
        /// </summary>
        public static Func<Item, bool> CreateCategoryFilter(Category category)
        {
            return item => item.Category == category;
        }

        /// <summary>
        /// Возвращает фильтр для названия, содержащего указанную подстроку.
        /// </summary>
        public static Func<Item, bool> CreateNameFilter(string substring)
        {
            return item => item.Name.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Возвращает комбинированный фильтр (И).
        /// </summary>
        public static Func<Item, bool> CombineAndFilters(params Func<Item, bool>[] filters)
        {
            return item =>
            {
                foreach (var filter in filters)
                {
                    if (!filter(item))
                        return false;
                }
                return true;
            };
        }

        /// <summary>
        /// Возвращает комбинированный фильтр (ИЛИ).
        /// </summary>
        public static Func<Item, bool> CombineOrFilters(params Func<Item, bool>[] filters)
        {
            return item =>
            {
                foreach (var filter in filters)
                {
                    if (filter(item))
                        return true;
                }
                return false;
            };
        }

        // === СПЕЦИАЛИЗИРОВАННЫЕ МЕТОДЫ ===

        /// <summary>
        /// Метод фильтрации товаров стоимостью выше 5000.
        /// </summary>
        public static List<Item> FilterItemsByCostAbove5000(List<Item> items)
        {
            Func<Item, bool> costFilter = CreateCostFilter(5000);
            return FilterItems(items, costFilter);
        }

        /// <summary>
        /// Метод фильтрации товаров по категории.
        /// </summary>
        public static List<Item> FilterItemsByCategory(List<Item> items, Category category)
        {
            Func<Item, bool> categoryFilter = CreateCategoryFilter(category);
            return FilterItems(items, categoryFilter);
        }

        /// <summary>
        /// Метод фильтрации товаров по первой категории из перечисления (Electronics).
        /// </summary>
        public static List<Item> FilterItemsByFirstCategory(List<Item> items)
        {
            Category firstCategory = Category.Electronics;
            Func<Item, bool> categoryFilter = CreateCategoryFilter(firstCategory);
            return FilterItems(items, categoryFilter);
        }
    }
}
