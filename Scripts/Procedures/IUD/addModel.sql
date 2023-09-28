create or replace PROCEDURE addModel(in_type in TypeOfAppliances.Name%TYPE,
in_producer in Producers.Producer%TYPE, in_model in Models.Model%TYPE)
IS
typeId number;
producerId Number;
modelExists number;
typeExists number;
producerExists number;
currModelExists exception;
producerTypeError exception;
producerTypeNoExistsError exception;
invalidData exception;
begin
    if in_type is null or in_producer is null 
    then raise invalidData;
    end if;
    select TypeOfAppliances.Id into typeId from TypeOFAppliances where TypeOFAppliances.Name = in_type;
    select Producers.Id into producerId from Producers where Producers.Producer = in_producer;
    SELECT COUNT(*) into modelExists from Models
    where Models.Model = in_model;
    SELECT COUNT(*) into typeExists from TypeOfAppliances 
    where TypeOfAppliances.Name = in_type;
    SELECT COUNT(*) into producerExists from Producers
    where Producers.Producer = in_producer;
    if modelExists != 0 then raise currModelExists;
    elsif (typeExists != 1 or producerExists != 1) then raise producerTypeError;
    elsif (typeExists = 0 or producerExists = 0) then raise producerTypeNoExistsError;
    end if;
    insert into Models(Model, ProducerId, TypeId)
    values (in_model, producerId, TypeId );
    exception
    when currModelExists then
    raise_application_error(-20002, 'Такая модель уже существует');
    when producerTypeError then
    raise_application_error(-20027, 'Ошибка с типом или продюссером - проверьте введённые данные');
    when producerTypeNoExistsError then
    raise_application_error(-20027, 'Тип техники или продюссер не существуют');
    when invalidData then
    raise_application_error(-20028, 'Проверьте введенные данные');
  commit;
end addModel;