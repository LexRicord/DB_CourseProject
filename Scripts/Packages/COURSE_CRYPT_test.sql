declare
    str varchar2(2000) := 'admin';
    str2 varchar2(2000);
    str3 raw(2000);
        str4 varchar2(2000);
    c raw(2000);
begin
    c := COURSE_CRYPT.ENCRYPTION_S(str);
    DBMS_OUTPUT.PUT_LINE(c);
    DBMS_OUTPUT.PUT_LINE(c);
    str2 := COURSE_CRYPT.DECRYPTION(c);
    DBMS_OUTPUT.PUT_LINE(str2);
    if str2 = str then DBMS_OUTPUT.PUT_LINE('EQUAL');
    end if;
    str3 := '764FD29C35622204B5192753E5A66BB9';
    if str3 = c then DBMS_OUTPUT.PUT_LINE('EQUAL2');
    end if;
    str4:= COURSE_CRYPT.DECRYPTION(str3);
    if (str4 = str and str3 = c) then DBMS_OUTPUT.PUT_LINE('EQUAL3');
    end if;
end;