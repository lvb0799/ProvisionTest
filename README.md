# ProvisionTest

MSSQL 資料表與預存程序、.NET 6 API、Vue 3 前端網站

## 專案結構


## 📂 DB (MSSQL)

- 包含：
  - 建立Table
  - 建立查詢與新增資料的預存程序 
- 使用方式：
  - 將 SQL 至 MSSQL 資料庫執行

## 💻 FrontEnd (Vue 3)

- 功能：
  - 使用表格顯示資料
- 使用方式：
  ```
  cd FrontEnd
  npm install
  npm run dev
  ```
## 🖥 BackEnd (.NET 6 Web API)
功能：

提供查詢與新增資料的 API

- 使用方式：
    ```
    cd BackEnd
    dotnet run
    ```
- 技術應用：
    - Swagger、MediatR、AutoMapper
