alter SESSION set NLS_DATE_FORMAT = 'DD-MM-YYYY HH24:MI:SS';
declare
d1 number;
d2 DATE;
d3 DATE;
d4 number;
begin
    d3 := '01-01-2023 01:00:00';
    d1 := 20;
    d2 := TO_DATE(d1,'HH24');
    DBMS_OUTPUT.PUT_LINE(d2);
    DBMS_OUTPUT.PUT_LINE(d3);
    d3 := TO_DATE(d1,'HH24');
    DBMS_OUTPUT.PUT_LINE(d3);
end;