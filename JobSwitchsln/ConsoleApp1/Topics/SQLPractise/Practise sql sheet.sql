

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



-- Show each customer's expense and the previous customer's expense in a single row

SELECT customername, expense, 
lag(expense, 1, 0) over (order by customerid) as PreviousExpense 
from Customers;



-- Rank products by price descending using RANK, DENSE_RANK, ROW_NUMBER

SELECT productname, 
ROW_NUMBER() over (order by productprice) as RowNumber,
RANK() over (order by productprice) as rnk,
DENSE_RANK() over (order by productprice) as DenseRank
FROM Products;



-- Show customers with row numbers per expense group.

select row_number() over (partition by expense order by customerid) as rn,
       customername, expense
from Customers



--  Find customers who share the same expense amount.

SELECT * FROM Customers where expense 
in (Select expense from Customers Group by expense having COUNT(*) > 1);

SELECT * FROM Customers c1
JOIN Customers c2 ON c1.expense = c2.expense 
where c1.customerid != c2.customerid;



-- Total expense per customer, sorted highest first.

SELECT customername, SUM(expense) as TotalExpense 
FROM Customers Group by customername
order by TotalExpense desc;





-- Get the customer count per month in 2023.

SELECT Month(createdate) as Month, Count(*) FROM Customers
where Year(createdate) = '2023' 
Group by Month(createdate) order by Month



-- Find products that no customer has purchased.

SELECT p.* FROM Products p 
LEFT JOIN Customers c On p.productbuyerid = c.customerid 
where c.customerid is null;



-- Get top 2 most expensive products per buyer.

With cte as(
SELECT productbuyerid, productname, productprice, DENSE_RANK() over (partition by productbuyerid order by productprice desc) as rnk from Products)

SELECT c.customername, t.productname, t.productprice FROM cte t
JOIN Customers c on t.productbuyerid = c.customerid where t.rnk <=2



-- Find all transactions that have no sender or receiver (still 'Empty').

SELECT * FROM Transactions where transactionto = 'Empty' and transactionfrom = 'Empty'



-- Use COALESCE and ISNULL to handle NULLs on Customer name.

SELECT customername, 
ISNULL(customername, 'Unknown') as WithIsNull,
COALESCE(null, customername, 'Default') as WithColesce
FROM Customers



-- Format expense and date using CAST and CONVERT.

SELECT customername, 
	CAST (expense as int) as IntExpense, 
	'$' + cast(cast(expense as int) as varchar) as FormattedExpense,
	CONVERT(varchar, createdate, 103) as DateDMY
FROM Customers; 



-- UPSERT — update customer if exists, insert if not.

declare @uid int = 15, @uName varchar(50) = 'Avishkar', @uex money = 55

If exists (SELECT 1 from Customers where customerid = @uid)
	BEGIN
		update Customers 
		SET customername = @uName, expense = @uex
		where customerid = @uid
	END
	
ELSE 
	BEGIN 
		Insert into Customers
		VALUES (@uid, @uName, @uex, GETDATE())
	END



-- Write a stored procedure to insert a customer.
GO
CREATE OR ALTER procedure sp_AddCustomer
	@cid int, 
	@cname varchar(20),
	@ex money,
	@date date
as 
BEGIN 
	INSERT INTO Customers 
	Values (@cid, @cname, @ex, @date)
END


execute sp_AddCustomer @cid=30, @cname='Vikram', @ex=75, @date='2024-01-01'

GO

-- Stored procedure to return the Nth highest product price.

CREATE OR ALTER procedure sp_NthHighestPrice
	@nth int
as
BEGIN
	with cte as (
	SELECT productname, DENSE_RANK() over (order by productprice desc) as rnk FROM Products)

	SELECT productname from cte where rnk = @nth
END

execute sp_NthHighestPrice 2



-- Transaction with TRY/CATCH that rolls back on error.

begin try
	begin transaction 
		INSERT INTO Customers values (9,'Ashwini',100,'2024-01-01')
			
		INSERT INTO Customers values (99,'Duplicate',100,'2024-01-01')
	commit transaction

end try 

begin catch
	rollback transaction 
	SELECT ERROR_MESSAGE() as ErrorMessage
end catch


-- 40 question done