use sample;
select [dbo].[udf_EmpNameDisplay](100,(select staff_sal from staff_Master where staff_Code=101 )) newsal;

select staff_sal from staff_master where staff_code=101