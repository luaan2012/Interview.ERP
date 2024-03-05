using Interview.Comission;

Seller[] sellers =
[
    new Seller(3000),
    new Seller(500),
    new Seller(700),
    new Seller(900),
    new Seller(4200),
    new Seller(5200),
    new Seller(1200),
    new Seller(2200),
    new Seller(8200),
    new Seller(8200),
    new Seller(8200),
    new Seller(12200),
];

AccountantSalaries counters = new();
counters.CountSalary(sellers);

counters.PrintResults();