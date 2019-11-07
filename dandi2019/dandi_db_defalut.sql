/* 사용자 정보 (회원가입 시 입력) */
create table user_info(
	user_id varchar(20) primary key,
    user_passwd varchar(20) not null,
    user_name varchar(20) not null,
    user_gender varchar(3) not null,
    user_age int(10) not null,
    user_height int(20) not null,
    user_weight int(20) not null,
    user_phone varchar(20) default '000-0000-0000'
);

/* 운동 정보 (등록된 운동)*/
create table fit_info (
	fit_name varchar(20) primary key,
    fit_core1 varchar(20),
    fit_core2 varchar(20),
    fit_core3 varchar(20),
    fit_resource varchar(100),
    fit_description text(300)
);

create table fit_record (
	user_id varchar(20),
	fit_name varchar(20),
    fit_date timestamp,
    fit_accuracy int(10), /*운동 완료 후 전체 정확도(일치율의 평균 값)*/
    constraint fk_fit_name foreign key (fit_name) references fit_info(fit_name),
    constraint fk_user_id foreign key (user_id) references user_info(user_id),
    constraint user_id_fit_name_date_combo_pk primary key(user_id, fit_name, fit_date)
);

show tables;

/*테이블 user_info 기본 쿼리문*/
desc user_info;
select * from user_info;
delete from user_info where user_id like 'a%';
drop table user_info;

/* 디폴트 데이타 user_info 삽입 */
insert into user_info values ('carinodudu', '1234', '김두환', '남', 27, 178, 68, '010-4181-9965');
insert into user_info values ('yuha', '1234', '정유하', '여', 24, 158, 42, '010-1234-1234');
insert into user_info values ('suyeon', '1234', '양수연', '여', 24, 158, 42, '010-1234-1234');
insert into user_info values ('hyunah', '1234', '장현아', '여', 25, 167, 48, '010-1234-1234');

/*테이블 fit_info 기본 쿼리문*/
desc fit_info;
select * from fit_info;
delete from fit_info;
drop table fit_info;

/* 디폴트 데이타 fit_info 삽입 */
insert into fit_info values ('발레스쿼트', '허리', '허벅지', '엉덩이', 'balletsquat.wmv', '어깨 넓이로 발을 벌리고 양 팔은 몸에 가볍게 붙인다. 밸런스를 취하며 숨도 들이쉬면서 그대로 무릎을 굽혀 허리 위 상반신을 내린다. 이 때에 발뒤꿈치를 절대 올리지 않는다. 상체를 가능한 똑바로 세워 허리의 등뼈가 아치형태를 유지하도록 한다. 허리가 굽어지면 부상의 원인이 된다.허벅지와 바닥이 평행을 이룰 때까지 허리를 낮춘다. 그리고 가능하면 평행 상태에서 1초 정도 머문다. 숨을 뱉으면서 무릎과 등을 세우면서 허리를 올린다.');
insert into fit_info values ('꽃게운동', '발목', '허벅지', '종아리', 'crap.wmv', '어깨 넓이로 발을 벌리고 양 팔은 몸에 가볍게 붙인다. 밸런스를 취하며 숨도 들이쉬면서 그대로 무릎을 굽혀 허리 위 상반신을 내린다. 이 때에 발뒤꿈치를 절대 올리지 않는다. 상체를 가능한 똑바로 세워 허리의 등뼈가 아치형태를 유지하도록 한다. 허리가 굽어지면 부상의 원인이 된다.허벅지와 바닥이 평행을 이룰 때까지 허리를 낮춘다. 그리고 가능하면 평행 상태에서 1초 정도 머문다. 숨을 뱉으면서 무릎과 등을 세우면서 허리를 올린다.');


/*테이블 fit_record 기본 쿼리문*/
desc fit_record;
select * from fit_record;
delete from fit_record;
drop table fit_record;

/* 디폴트 데이타 fit_record 삽입 */
insert into fit_record values ('yuha', '발레스쿼트', now(), 77);
insert into fit_record values ('yuha', '발레스쿼트', now(), 80);
insert into fit_record values ('yuha', '발레스쿼트', now(), 73);
insert into fit_record values ('yuha', '발레스쿼트', now(), 82);
insert into fit_record values ('yuha', '발레스쿼트', now(), 80);
insert into fit_record values ('yuha', '발레스쿼트', now(), 88);
insert into fit_record values ('yuha', '발레스쿼트', now(), 99);
insert into fit_record values ('yuha', '발레스쿼트', now(), 90);
insert into fit_record values ('yuha', '꽃게운동', now(), 97);

