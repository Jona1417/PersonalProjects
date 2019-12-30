
AUTHOR: Jonathan Vidal-Contreras

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~ CurrencyCalculator VERSION 1.0 ~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

(2019/12/16) 10:30 AM

-This calculator is intended specifically for people wanting to convert USD to the Venezuelan Bolivar, due to the rising number of Venezuelan refugees
	arriving to the US. In future versions, there might be a simultaneous conversion to Pesos Colombianos.
- I'm unsure of the conversion to VEF, but to Colombian pesos, my guess is about 2800 to 3000 COP to 1 dollar.
- NOTE: Western Union's website offered no conversion rate to VEF from USD; in fact, money transfer services are unavailable.

-Challenges: 
	-Every website offers a slightly different conversion rate for currencies. I plan on placing a few options for rates when making calculations:
		- If available, Western Union
		- Results that appear at the top of a Google search results page
		- maybe xe.com?
		- If possible, reputable institutions located/based in Colombia/Venezuela
		- Allow the users to access the websites involved to find the most accurate/current conversion rates and use them in the calculator--
			A "manual mode", if you will.
		- An average of these rates, so users can receive a general idea as to how much money the recipient should get.
	-As with every nation, socioeconomic circumstances may affect the stability/volatility of currency conversion rates. In later versions, I would
	like to have the program obtain conversion rate updates on a daily/weekly basis for best accuracy, but I'm not sure how to implement that at this point.

- NOTE: Because these are estimates, there should be a disclaimer letting the user know that there is no full guarantee that the rates/values 
	should be considered as exact; users should allow for a margin of error when using the calculator/sending money. Also, they should consider fees
	involved when using some services to send money (like sending to/from a debit card, bank account, etc.)
	-THIS CALCULATOR CANNOT BY ITSELF SEND THE USER'S MONEY TO SOME INTENDED RECIPIENT. Nor do I intend on implementing such functionality.

-DESIGN:
	- The CurrencyCalculator project follows the MVC pattern.
		- Model: The Calculator project will deal with the logic of performing currency conversion and calculations.

		- View: The CalculatorView project will trigger events that occur in the Form and call methods in the Controller.

		- Controller: The CalcController class will deal with the events and call methods in the model that will handle the logic
			of calculation, etc.

(2019/12/18)

-Removed the ExchangeRateTextBox, which displayed the various rates and the average exchange rate between currencies. Now in its place there
	is a series of radio buttons that allow for the user to pick an exchange rate that they would like to use for their calculations.
	-TODO: implement the choices leading to different calculation results based on their choosing from 1 of the radio buttons.


~~~~~~~~~~~~~~~~~~~
~~~ VERSION 1.1 ~~~
~~~~~~~~~~~~~~~~~~~

(2019/12/23)

-Adding conversion rates for Brazilian Reales and Chilean Pesos.
-The format of options for selecting currency will be guaranteed to be the following:
	FULL NAME OF CURRENCY (CURRENCY CODE) where the CURRENCY CODE is 3 letters.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
~~~ CurrencyCalculator Version 2.0 ~~~
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

NOTE: WHEN UPDATING THE INSTALLER, FIRST BUILD/REBUILD THE INSTALLER PROJECT (not the solution) AND TEST REINSTALLING

(2019/12/23)
-Created a separate branch for this attempt at version 2.0
-Created a mySQL server/database that will contain the exchange rates (which me/an admin of the database can update using mySQL workbench)
-How do I make a server that can allow remote connections (ie, different wifi networks) ?
-I must create a user that has access to reading, not modifying the database, but also use an IP/website that allows for clients to connect 
	and receive updates on exchange rates. Probably will use a generic name like "user" for accessing the database.
	-user: newuser -- password = test_password1

(2019/12/27) 12:05 PM
-Added a "LastUpdated" column to the currency exchange rate tables on the currency_exchange_rates database.
	-This indicates the time that the values were most recently updated, and I will use that info to display on the bottom right corner
		of the GUI. I have chosen the chile table in particular to display the time of last update, because the Venezulan currency table
		has rates that don't change, so those timestamps will be outdated with respect to the rest of the database.
-Should I let the user manually choose when to update the CurrencyCalculator's exchange rate values or let it do so automatically as 
	I update the database?

1:24 PM
-Shifted code from the Calculator class into the CalcController class to more closely follow the MVC structure for this program.
	Everything so far seems to still be functional.

~~~~~~~~~~
Version 2.1
~~~~~~~~~~
- Fixed bug with too many error messages displaying when a connection fails. Still need to figure out remote connection.

~~~~~~~~~~~
Version 2.2
~~~~~~~~~~~
-Will try to add a manual connection button so the user can choose to connect to a database.
-Will create an XML file that will contain the currency exchange rates so the user can have a more "updated" (ie, less outdated)
	set of currency exchange rates, based on the last time the application was able to connect to the CER.