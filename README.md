# MVC .NET E-Commerce Store

## Description

This is an MVC .NET eCommerce application designed with an N-tier architecture, featuring separate projects for Data Access, Models, and Utilities. The application allows customers to create accounts, browse books, see discounts, and add items to their cart. Admins can manage the book catalog, including creating new books with rich-text descriptions using CkEditor, updating existing books, and categorizing them (e.g., Programming, History). The application uses Entity Framework Core for database operations.

## Features

- **Customer Functions:**
  - Create and manage accounts using `IdentityDbContext`.
  - Browse books with details including name, author, description, ISBN, and image.
  - View discounts and add books to the shopping cart.

- **Admin Functions:**
  - Create new books with interactive rich-text descriptions using CkEditor.
  - Update existing books.
  - Manage book categories with foreign key relationships.

- **Architecture:**
  - **N-Tier Architecture:**
    - **Presentation Layer:** Handles user interactions and displays information.
    - **Business Logic Layer:** Contains the core business logic and rules.
    - **Data Access Layer:** Manages database operations using Entity Framework Core.
    - **Models Layer:** Defines the data structures, including books, categories, and user accounts.
    - **Utilities Layer:** Provides common functionalities and helper methods.

## Architecture Details

- **MVC Pattern:**
  - **Model:** Defines the data structure, including books, categories, and user accounts.
  - **View:** Handles the user interface, displaying book details, forms for account management, and cart functionalities.
  - **Controller:** Manages user interactions, data processing, and updates to the view.

- **Identity Management:**
  - Utilizes `IdentityDbContext` for user authentication and account management.

- **Rich-Text Editor:**
  - Integrates CkEditor for dynamic book descriptions with formatting options.

## Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/mehboob14/Ecommerce_Store.git
