create or replace PACKAGE COURSE_CRYPT AS
key_bytes_raw raw(32) := '88CBDA29C1EC8E65F4A865EC3FCC5C9F71AE6B7E5407EA445E87B17F2221AE14';

function ENCRYPTION_S(input_str varchar2)
return raw;
function DECRYPTION(input_dec raw)
return varchar2;
END COURSE_CRYPT;

create or replace PACKAGE BODY COURSE_CRYPT AS
function DECRYPTION(input_dec raw)
return varchar2 is
    output_string      VARCHAR2 (2000);
    decrypted_raw      RAW (2000);             -- stores decrypted binary text
    encryption_type    PLS_INTEGER :=          -- total encryption type
                            DBMS_CRYPTO.ENCRYPT_AES256 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5;
begin
    decrypted_raw := DBMS_CRYPTO.DECRYPT
      (
         input_dec,
         encryption_type,
         key_bytes_raw
      );
    output_string := UTL_I18N.RAW_TO_CHAR (decrypted_raw, 'AL32UTF8');
    return output_string;
end DECRYPTION;

function ENCRYPTION_S(input_str varchar2)
return raw is
    encoded_string raw(2000);
    encryption_type    PLS_INTEGER :=          -- total encryption type
                            DBMS_CRYPTO.ENCRYPT_AES256 + DBMS_CRYPTO.CHAIN_CBC + DBMS_CRYPTO.PAD_PKCS5;
begin
    encoded_string:= DBMS_CRYPTO.ENCRYPT
      (
         UTL_I18N.STRING_TO_RAW (input_str, 'AL32UTF8'),
         encryption_type,
         key_bytes_raw
      );
    return encoded_string;
end ENCRYPTION_S;
END COURSE_CRYPT;