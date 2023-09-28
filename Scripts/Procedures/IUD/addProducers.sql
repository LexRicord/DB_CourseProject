create or replace PROCEDURE addProducers(in_name in Producers.Producer%TYPE)
IS
producerExists number;
currServiceExists exception;
invalidData exception;
begin
    if in_name is null then raise invalidData;
    end if;
    SELECT COUNT(*) into producerExists from Producers
    where Producers.Producer = in_name;
    if producerExists != 0 then raise currServiceExists;
    end if;
    insert into Producers(Producer)
    values (in_name);
    exception
    when currServiceExists then
    raise_application_error(-20002, 'Такой производитель существует');
    when invalidData then
    raise_application_error(-20028, 'Проверьте введенные данные');
  commit;
end addProducers;