fid = fopen('KeyStrokes.txt');
tline = fgetl(fid);
tlines = cell(0,1);
while ischar(tline)
    tlines{end+1,1} = tline;
    tline = fgetl(fid);
end
RS = [];
RE = [];
fclose(fid);
for i = 1 : length(tlines)
    curr = char(tlines(i));
    curr = curr(2:3);
    if curr == 'RS'
        RS(end+1) = i;
    end
    if curr == 'RE'
        RE(end + 1) = i;
    end
end
for i = 1 : length(RS)
    beg = RS(i);
    ending = RE(i);
    begVal = char(tlines(beg));
    endVal = char(tlines(ending));
    begVal = str2double(begVal(4:end));
    endVal = str2double(endVal(4:end));
    sizeOfArr = (endVal - begVal) * 1000;
    out = zeros(int32(sizeOfArr));
    heldDown = -1;
    for j = beg + 1 : ending - 1
        curr = char(tlines(j));
        currStat = curr(2:3);
        currVal = curr(4:end);
        if (currStat == 'KH')
            if j ~= (ending - 1)
                heldDown = int32(str2double(currVal) * 1000);
            end
        end
        if (currStat == 'KH')
            if j == ending - 1
                for k = heldDown : endVal
                    out(k) = 1;
                end
                heldDown = -1;
            end
        end
        if currStat == 'KR'
            for k = heldDown : heldDown + int32(str2double(currVal) * 1000)
                out(k) = 1;
            end
            heldDown = -1;
        end
    end
end
