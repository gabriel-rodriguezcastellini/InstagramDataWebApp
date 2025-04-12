# Instagram Data Web App

A .NET 9 ASP.NET Core MVC application that reads and displays Instagram export JSON data. The application features dynamic list updates using AJAX, pagination using X.PagedList, sorting and filtering options.

## Features

- **Data Import:** Reads exported JSON files from Instagram such as followers, following, blocked users, pending follow requests, and more.
- **Pagination:** Integrates with the [X.PagedList.Mvc.Core](https://github.com/dncuug/X.PagedList) library to paginate large datasets.
- **Sorting & Filtering:** Provides options to sort by username or date and to filter the lists by search terms.
- **AJAX Updates:** Uses jQuery to load data dynamically without reloading the entire page, enhancing the user experience.
- **Responsive UI:** Uses [Bootstrap 5](https://getbootstrap.com/) for styling and responsive design.