CREATE TABLE GDUsers_Cards  (
    id INT PRIMARY KEY,
    card_type VARCHAR(MAX) NOT NULL,
    balance FLOAT NOT NULL,
    month_limit INT NOT NULL,
    account_name VARCHAR(MAX) NOT NULL,
    card_holder VARCHAR(MAX) NOT NULL,
    cashback FLOAT NOT NULL,
    monthly_fee FLOAT NOT NULL,
    interest_rate FLOAT NOT NULL,
    overdraft_protection INT NOT NULL,
    creation_date date NOT NULL,
    account_id INT NOT NULL
);