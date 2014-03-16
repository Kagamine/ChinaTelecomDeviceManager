drop table if exists `users`;
drop table if exists `device_types`;
drop table if exists `devices`;
drop table if exists `scans`;

CREATE TABLE `users` (
    `id` int not null auto_increment,
    `username` varchar(50) not null,
    `password` varchar(50) not null,
    `display_name` varchar(50) not null,
    `role` tinyint not null,
    primary key (`id`),
    unique index (`username`)
)  default charset=utf8;

CREATE TABLE `device_types`(
    `id` int not null auto_increment,
    `provider` varchar(50) not null,
    `model` varchar(50) not null,
    primary key (`id`)
)  default charset=utf8;

CREATE TABLE `devices`(
    `id` int not null auto_increment,
    `device_type_id` int not null,
    `first_scan_time` datetime not null,
    primary key (`id`),
    foreign key (`device_type_id`)
    	references device_types (`id`)
    	on delete cascade
)  default charset=utf8;

CREATE TABLE `scans`(
	`id` int not null auto_increment,
	`device_id` int not null,
	`user_id` int not null,
	`time` datetime not null,
	`type` tinyint not null,
	primary key (`id`),
	foreign key (`device_id`)
		references devices(`id`)
		on delete cascade,
	foreign key (`user_id`)
		references users(`id`)
		on delete cascade
)  default charset=utf8;

INSERT INTO `users` (`username`, `password`, `display_name`, `role`) VALUES ('admin', 'admin', 'admin', 2);