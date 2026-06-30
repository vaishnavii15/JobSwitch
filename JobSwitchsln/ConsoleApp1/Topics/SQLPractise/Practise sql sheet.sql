

SELECT top 1 * FROM Customers order by expense desc

SELECT * FROM Products where productprice > 70

SELECT  * FROM Customers where customername like 'R%';
	
SELECT * FROM Customers where expense >= 60 and  expense <= 90

SELECT * FROM Customers where expense in (50, 70, 90)

SELECT COUNT (*) from Customers 


-- Minimum and max Product price

SELECT Max(productprice) as MaxProductPrice, Min(productprice) as MinProductPrice from Products



-- Total expense across all customers 

SELECT SUM(expense) from Customers



-- Avg expense per customer 

SELECT Avg(expense) from Customers



-- List customers ordered by expense descending

SELECT * from Customers order by expense desc



-- List customers ordered by expense descending.

SELECT * FROM Customers where Year(createdate) = 2023



-- Find the most recently registered customer

SELECT top 1* FROM Customers order by createdate desc



-- List customers along with the products they purchased (INNER JOIN).

SELECT c.customername, p.productname FROM Customers c
INNER JOIN Products p ON c.customerid  = p.productbuyerid;



-- List ALL customers, including those without any product (LEFT JOIN).

SELECT * FROM Customers c
LEFT JOIN Products p ON c.customerid = p.productbuyerid;



-- Find customers who have NOT bought any product.

SELECT * FROM Customers c 
LEFT JOIN Products p ON c.customerid = p.productbuyerid where p.productbuyerid is null;



-- Get total revenue per product name.

SELECT productname, Sum(productprice) FROM Products 
GROUP by (productname);



-- List product names that have more than one unit.

SELECT  productname, COUNT(*) as Units FROM Products 
GROUP by (productname) HAVING COUNT(*) > 1;



-- Find customers whose expense is above the average expense.

SELECT * FROM Customers 
where expense > (SELECT Avg(expense) from Customers);



-- Find the 2nd highest expense (without TOP).

SELECT Max(expense) as SecondHighestExpense 
FROM Customers 
where expense < (select MAX(expense) from Customers);



-- Find the Nth highest expense using DENSE_RANK (N = 3) ---
--IMPPPPPPP 

with Ranked as (
select expense, dense_rank() 
over (order by expense desc) as rnk
    from Customers
)
Select distinct expense from Ranked where rnk = 3;



-- Categorize customers by expense (High / Medium / Low) using CASE.

SELECT customername, expense ,
CASE 
    when expense >= 100 then 'High'
    when expense >=  70 then 'Medium'
    else 'Low' 
   end AS Category
FROM Customers;



-- Show customers with a running total of expenses ordered by customerid.

SELECT customername, expense, 
sum(expense) over (order by customerid rows unbounded preceding) as RunningTotal
FROM Customers

-- 25 question done 