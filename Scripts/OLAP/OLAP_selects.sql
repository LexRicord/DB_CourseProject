SELECT
  TYPEDIM,
  PRODUCERDIM,
  MODELDIM,
  COUNT(NUMBEROFMODELS) AS TOTAL_MODELS
FROM
  TYPECUBE_view
WHERE
  MODELDIM IS NOT NULL
GROUP BY
  TYPEDIM,
  PRODUCERDIM,
  MODELDIM;

SELECT
  TYPEOFAPPLIANCES.NAME,
  PRODUCERS.PRODUCER,
  COUNT(MODELS.MODEL) AS NUMBEROFMODELS 
FROM
  MODELS
JOIN
  TYPEOFAPPLIANCES ON MODELS.TYPEID = TYPEOFAPPLIANCES.ID
JOIN
  PRODUCERS ON MODELS.PRODUCERID = PRODUCERS.ID
GROUP BY
  TYPEOFAPPLIANCES.NAME,
  PRODUCERS.PRODUCER;