
--! note: code isn't 100% correct.
-- This is meant to help understand all the tile types needed

-- Helper function to format tile string as "AA-AA-AA-AA"
function format_tile(tile)
    return tile:sub(1,2) .. "-" .. tile:sub(3,4) .. "-" .. tile:sub(5,6) .. "-" .. tile:sub(7,8)
end

-- Function to rotate a tile string clockwise (90 degrees)
function rotate_clockwise(tile)
    -- return tile:sub(7,8) .. tile:sub(5,6) .. tile:sub(3,4) .. tile:sub(1,2)
    return tile:sub(7,8) .. tile:sub(1,2) .. tile:sub(3,4) .. tile:sub(5,6)
end

-- Function to flip horizontally
function flip_horizontal(tile)
    return tile:sub(3,4) .. tile:sub(1,2) .. tile:sub(7,8) .. tile:sub(5,6)
end

-- Function to flip vertically
function flip_vertical(tile)
    return tile:sub(5,6) .. tile:sub(7,8) .. tile:sub(1,2) .. tile:sub(3,4)
end

-- Generate all transforms (rotations + flips)
function get_all_transformations(tile)
    local transformations = {}

    -- Generate all 8 possible transformations
    local rotated90 = rotate_clockwise(tile)
    local rotated180 = rotate_clockwise(rotated90)
    local rotated270 = rotate_clockwise(rotated180)

    local flippedH = flip_horizontal(tile)
    local flippedV = flip_vertical(tile)
    local flippedH90 = flip_horizontal(rotated90)
    local flippedV90 = flip_vertical(rotated90)

    -- Store only unique transformations
    local unique = { [tile] = true, [rotated90] = true, [rotated180] = true, [rotated270] = true,
                     [flippedH] = true, [flippedV] = true, [flippedH90] = true, [flippedV90] = true }

    -- Convert keys back to a list
    local transformed_list = {}
    for k, _ in pairs(unique) do
        table.insert(transformed_list, k)
    end

    return transformed_list
end

-- Function to generate all unique tiles
function generate_unique_tiles(possible_chars)
    local results = {}

    -- Generate all possible 8-character tile strings
    local function generate_combinations(current)
        if #current == 8 then
            local tile_str = table.concat(current)

            -- Check if this tile (or any of its transformations) already exists
            local transformations = get_all_transformations(tile_str)
            table.sort(transformations) -- Ensures we store only the canonical (smallest) form

            local canonical = transformations[1] -- The smallest string representation
            if not results[canonical] then
                results[canonical] = true
                print(format_tile(canonical)) -- Print the unique tile in AA-AA-AA-AA format
            end
            return
        end
        for _, char in ipairs(possible_chars) do
            table.insert(current, char)
            generate_combinations(current)
            table.remove(current)
        end
    end

    generate_combinations({})
end

-- Example usage:
possible_chars = {"W", "D"} -- Define possible connection types
-- generate_unique_tiles(possible_chars)
print(table.concat(get_all_transformations("DWWWWWWW"), ","))


