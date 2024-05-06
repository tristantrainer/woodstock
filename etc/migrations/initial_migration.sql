create table transactions (
	id INTEGER NOT NULL UNIQUE,
	public_id
	description VARCHAR(255) NOT NULL,
	date TIMESTAMP WITH TIME ZONE,
	value DECIMAL NOT NULL
);