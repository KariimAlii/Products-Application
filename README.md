# ProductsApplication

[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/21335276-6a258369-8dbf-484e-ae6e-c4f9b1627411?action=collection%2Ffork&source=rip_markdown&collection-url=entityId%3D21335276-6a258369-8dbf-484e-ae6e-c4f9b1627411%26entityType%3Dcollection%26workspaceId%3D6fa2eac5-033c-4e08-aae1-5fb8560188c7)


1. Authentication:
        · Users should be able to sign up, sign in, and sign out of the application using their email address and password.
        · User registration should include first name, last name, email address, and password fields.
        · Passwords should be hashed and salted before being stored in the database.
2. Authorization:
        · Each API endpoint should have a permission that determines which users can access it.
        · Permissions should be defined in the database and associated with each user role.
        · The following roles should be defined: Administrator, Manager, and User.
        · The Administrator role should have access to all API endpoints.
        · The Manager role should have access to the products API endpoint only.
        · The User role should not have access to any API endpoint.
3. Product API:
        · Authenticated users with the correct permission should be able to perform CRUD operations on the products API endpoint.
        · The products API endpoint should be secured with authorization to ensure only users with the correct permissions can access it.
        · The endpoint should support the following operations:
                · GET /api/products: Get a list of all products.
                · GET /api/products/{id}: Get a single product by ID.
                · POST /api/products: Create a new product.
                · PUT /api/products/{id}: Update an existing product by ID.
                · DELETE /api/products/{id}: Delete a product by ID.
        · Each product should have the following properties:
                · ID: Unique identifier for the product.
                · Name: Name of the product.
                · Description: Description of the product.
                · Price: Price of the product.
                Image: Image of the product.