puts "Please the byte of data you want to encode (8 bits)"
to_encode = gets.chomp

while to_encode.length != 8
puts "Incorrect byte of data length"
to_encode = gets.chomp
end

e_length = to_encode.length
curr_val = 0

until 2 ** curr_val > e_length

puts 2 ** curr_val
to_encode.insert(2 ** curr_val - 1, '_')

curr_val += 1

end

puts "Encodierter Hamming-Code: " << to_encode
