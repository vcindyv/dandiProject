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
    fit_date timestamp default current_timestamp, /*아무런 값도 입력 받지 않으면 현재 시간을 Defalut 값으로 설정*/
    fit_accuracy int(10), /*운동 완료 후 전체 정확도(일치율의 평균 값)*/
    constraint fk_fit_name foreign key (fit_name) references fit_info(fit_name),
    constraint fk_user_id foreign key (user_id) references user_info(user_id),
    constraint user_id_fit_name_date_combo_pk primary key(user_id, fit_name, fit_date)
);

alter table fit_record add fit_date timestamp default CURRENT_TIMESTAMP;

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

/*운동 설명 fit_description 수정*/
update fit_info set fit_description = '양 팔은 바닥과 수평이 되도록 벌리고 천천히 양 팔을 머리 위로 박수를 친다고 생각하며 들어올린다. 양 팔이 귀에 닿을 정도로 올린 후 천천히 내린다.' where fit_name = '나비운동';

/*운동 설명 fit_resource 수정*/
update fit_info set fit_resource = 'du_ballet.mp4' where fit_name = '발레스쿼트';
update fit_info set fit_resource = 'du_crab.mp4' where fit_name = '꽃게운동';
update fit_info set fit_resource = 'du_navi.mp4' where fit_name = '나비운동';
update fit_info set fit_resource = 'du_velly.mp4' where fit_name = '옆구리운동';
update fit_info set fit_resource = 'du_leg.mp4' where fit_name = '다리운동';
update fit_info set fit_resource = 'du_pt.mp4' where fit_name = 'PT체조';

/* 디폴트 데이타 fit_info 삽입 */
insert into fit_info values ('발레스쿼트', '허리', '허벅지', '엉덩이', 'reference_situp.mp4', '양 팔은 바닥과 수평이 되도록 벌리고 양 발 뒷꿈치는 맞대어 다리를 O자 모양으로 만들며 천천히 내려갔다가 올라온다.');
insert into fit_info values ('꽃게운동', '발목', '허벅지', '종아리', 'reference_situp.mp4', '발을 어깨 너비만큼 벌리고 상체는 살짝 숙인 상태를 유지한다. 오른쪽으로 이동할 때 오른발 한 보 따라서 왼발 한 보씩 두번 이동한다. 왼쪽도 마찬 가지로 반대로 이동한다.');
insert into fit_info values ('나비운동', '팔', '어깨', '옆구리', 'reference_situp.mp4', '양 팔은 바닥과 수평이 되도록 벌리고 천천히 양 팔을 머리 위로 박수를 친다고 생각하며 들어올린다. 양 팔이 귀에 닿을 정도로 올린 후 천천히 내린다.');
insert into fit_info values ('옆구리운동', '허리', '옆구리', '팔', 'reference_situp.mp4', '발을 어깨 너비만큼 벌리고 양 팔은 바닥과 수직이 되도록 만세 자세를 취한다. 정면을 바라보면서 오른쪽으로 상체를 기울인다. 왼쪽도 마찬가지로 반대로 한다.');
insert into fit_info values ('다리운동', '허벅지', '종아리', '엉덩이', 'reference_situp.mp4', '양 팔은 바닥과 수평이 되도록 벌리고 다리는 어깨 너비의 절반 만큼 벌린다. 무릎이 정면을 향한 상태에서 오른쪽 다리를 골반에 자극이 올 정도까지 천천히 올린 후 내린다. 왼쪽도 마찬가지로 반대로 한다.');
insert into fit_info values ('PT체조', '어깨', '허벅지', '종아리', 'reference_situp.mp4', '차렷 자세에서 가볍게 점프하면서 양 발을 어깨 너비만큼 벌리고 첫번째 동작은 양 팔을 바닥과 수평이 되도록 벌린다. 두번째 동작은 동시에 양 팔을 벌리듯이 둥글게 위로 뻗어 귀에 붙이면서 양 손바닥은 서로 마주보도록 한다. 첫번째 동작과 두번째 동작을 번갈아가며 반복한다.');


/*테이블 fit_record 기본 쿼리문*/
desc fit_record;
select * from fit_record;
delete from fit_record;
drop table fit_record;

/* 디폴트 데이타 fit_record 삽입 발레스쿼트 */
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 77);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 77);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 87);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 90);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 56);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 78);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 80);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 43);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 57);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 60);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 65);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 70);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '발레스쿼트', 78);

/* 디폴트 데이타 fit_record 삽입 나머지 */
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 77);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 77);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 87);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 90);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 56);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 78);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '꽃게운동', 80);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '나비운동', 43);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '나비운동', 57);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '나비운동', 60);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '나비운동', 65);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '옆구리운동', 70);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '옆구리운동', 78);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '옆구리운동', 77);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '옆구리운동', 77);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '옆구리운동', 87);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '다리운동', 90);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '다리운동', 56);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '다리운동', 78);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '다리운동', 80);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', '다리운동', 43);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', 'PT체조', 57);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', 'PT체조', 60);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', 'PT체조', 65);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', 'PT체조', 70);
insert into fit_record (user_id, fit_name, fit_accuracy) values ('yuha', 'PT체조', 78);


