
GameLoopLua = {
    List = {}
}

local function Init()
    print("GameLoopLua Init")
    
end

GameLoopLua.Init = Init



local function Update()
    if #GameLoopLua.List > 0 then
        for key, value in pairs(GameLoopLua.List) do
            value:Update()
        end
    end
end

GameLoopLua.Update = Update

local function FixedUpdate()
    if #GameLoopLua.List > 0 then
        for key, value in pairs(GameLoopLua.List) do
            value:FixedUpdate()
        end
    end
end

GameLoopLua.FixedUpdate = FixedUpdate

