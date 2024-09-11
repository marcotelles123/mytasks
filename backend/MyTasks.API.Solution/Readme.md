backend:
	- db:
		- CREATE DATABASE mytasks
		- CREATE TABLE public.mytasks (
			id serial4 NOT NULL,
			title text NOT NULL,
			description text NULL,
			CONSTRAINT mytasks_pkey PRIMARY KEY (id)
		);
		
	run api:
	 - cd .\MyTasks.API
	 - dortnet run
	 - http://localhost:5249/swagger/index.html

frontend:
	run:
	- npm install
	- ng serve
	tests
		- cypress:
			- npx cypress open
			- npx cypress run

docker:
 - docker build -t mytasks-api:latest .
 - docker build -t mytasks-app:latest .
 - docker-compose up --build -d
 - docker exec -it mytasksapisolution-api-1 bash
