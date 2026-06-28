

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

--- 15 questions done