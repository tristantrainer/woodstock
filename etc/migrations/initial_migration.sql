-- Goose Down (not setup)
DROP TABLE IF EXISTS public.transactions;
DROP TABLE IF EXISTS public.individual_collectives;
DROP TABLE IF EXISTS public.collectives;
DROP TABLE IF EXISTS public.individuals;

-- Goose Up (not setup)
CREATE TABLE public.individuals
(
    id SERIAL NOT NULL DEFAULT,
    public_id UUID NOT NULL,
    first_name VARCHAR(255) NOT NULL,
    last_name VARCHAR(255) NOT NULL,
    username VARCHAR(255) NOT NULL,
    CONSTRAINT pk_individuals PRIMARY KEY (id),
    CONSTRAINT unique_individuals_public_id UNIQUE (public_id),
    CONSTRAINT unique_individuals_username UNIQUE (username)
);

CREATE TABLE public.collectives
(
    id SERIAL NOT NULL DEFAULT,
    public_id UUID NOT NULL,
    name VARCHAR(255) NOT NULL,
    created_by UUID NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL,
    CONSTRAINT pk_collectives PRIMARY KEY (id),
    CONSTRAINT unique_collectives_public_id UNIQUE (public_id),
    CONSTRAINT fk_collectives_created_by_individuals FOREIGN KEY (created_by)
        REFERENCES public.individuals (public_id)
);

CREATE TABLE public.individual_collectives
(
    id SERIAL NOT NULL DEFAULT,
    individual_id UUID NOT NULL,
    collective_id UUID NOT NULL,
    CONSTRAINT pk_individual_collectives PRIMARY KEY (id),
    CONSTRAINT fk_individual_collectives_collective_id_collectives FOREIGN KEY (collective_id)
        REFERENCES public.collectives (public_id),
    CONSTRAINT fk_individual_collectives_individual_id_individuals FOREIGN KEY (individual_id)
        REFERENCES public.individuals (public_id)
);

CREATE TABLE public.transactions
(
    id SERIAL NOT NULL DEFAULT,
    public_id UUID NOT NULL,
    collective_id UUID NOT NULL,
    description VARCHAR(255) NOT NULL,
    date TIMESTAMP WITH TIME ZONE NOT NULL,
    value DECIMAL NOT NULL,
    created_by UUID NOT NULL,
    created_at TIMESTAMP WITH TIME ZONE NOT NULL,
    CONSTRAINT pk_transactions PRIMARY KEY (id),
    CONSTRAINT unique_transactions_public_id UNIQUE (public_id),
    CONSTRAINT fk_transactions_collective_id_collectives FOREIGN KEY (collective_id)
        REFERENCES public.collectives (public_id),
    CONSTRAINT fk_transactions_created_by_individuals FOREIGN KEY (created_by)
        REFERENCES public.individuals (public_id)
)