CREATE TABLE IF NOT EXISTS public.mytasks (
    id serial4 NOT NULL,
    title text NOT NULL,
    description text NULL,
    CONSTRAINT mytasks_pkey PRIMARY KEY (id)
);

