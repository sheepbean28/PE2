
UPDATE
    ShieldingBox
SET
    ShieldingBox.Cp_date = v_ShlidingBoxTrans.量測日期,
    ShieldingBox.Limit_date = v_ShlidingBoxTrans.到期日期
FROM
    ShieldingBox AS ShieldingBox
    INNER JOIN v_ShlidingBoxTrans AS v_ShlidingBoxTrans
        ON ShieldingBox.Asset_no = v_ShlidingBoxTrans.aa
