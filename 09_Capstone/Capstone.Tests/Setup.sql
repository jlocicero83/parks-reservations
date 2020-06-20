--begin transaction

delete from reservation
--select * from reservation
delete from site
--select * from site
delete  from campground
--select * from campground
delete from park
--select * from park

insert into park (name, location, establish_date, area, visitors, description)
	values ('Tech Elevator Park', 'Cleveland', '2020-03-02', 4, 28, 'A park...')

Declare @park_id int
Select @park_id = @@IDENTITY

insert into campground (park_id, name, open_from_mm, open_to_mm, daily_fee)
	values (@park_id, 'TE Camp', 11, 12, 20.00)

declare @campground_id INT
select @campground_id = @@IDENTITY

insert into site (campground_id, site_number, max_occupancy, accessible, max_rv_length, utilities)
	values (@campground_id, 1, 78, 1, 12, 0)

declare @site_id int
select @site_id = @@IDENTITY
insert into reservation (site_id, name, from_date, to_date, create_date)
	values (@site_id, 'Jenkins', '2020-04-09', '2020-04-11', '2020-03-01')
--select * from reservation
Select @park_id As ParkId, @campground_id As CampgroundID, @site_id As SiteID

--rollback transaction