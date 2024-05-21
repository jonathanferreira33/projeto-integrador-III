SELECT * FROM db_stockmanager.tb_category;
SELECT * FROM db_stockmanager.tb_role;

INSERT INTO db_stockmanager.tb_category (id, description, createAt)
VALUES (1,'none', now()), (2,'alimenticio', now()), (3,'roupas', now()), (4,'higiene', now()), (5,'higiene pessoal', now()), (6,'kit', now());

INSERT INTO db_stockmanager.tb_role (id, description, level, createAt)
VALUES (1, 'ANALISTA', 1, now()), (2, 'ADM', 2, now()), (3, 'MANAGER', 3, now()), (4, 'MASTER', 4, now());
